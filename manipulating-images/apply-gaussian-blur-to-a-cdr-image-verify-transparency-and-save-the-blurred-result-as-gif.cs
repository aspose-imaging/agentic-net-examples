// HOW-TO: Apply Gaussian Blur to CDR Image and Save as Transparent GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputCdrPath = "input.cdr";
            string outputGifPath = "output.gif";

            if (!File.Exists(inputCdrPath))
            {
                Console.Error.WriteLine($"File not found: {inputCdrPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputCdrPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        var blurOptions = new GaussianBlurFilterOptions
                        {
                            Radius = 5,
                            Sigma = 1.5f
                        };
                        raster.Filter(raster.Bounds, blurOptions);

                        int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                        bool hasTransparency = false;
                        foreach (int pixel in pixels)
                        {
                            int alpha = (pixel >> 24) & 0xFF;
                            if (alpha != 255)
                            {
                                hasTransparency = true;
                                break;
                            }
                        }

                        Console.WriteLine(hasTransparency ? "Image has transparency." : "Image is opaque.");

                        raster.Save(outputGifPath, new GifOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to add a soft blur effect to a CorelDRAW (CDR) illustration before converting it to a GIF for web display.
 * 2. When you must preserve the original transparency of a CDR file after applying image filters and saving it as a GIF.
 * 3. When you want to rasterize a vector CDR file in memory, apply a Gaussian blur, and output a lightweight GIF without creating intermediate files on disk.
 * 4. When you are automating a batch process that blurs multiple CDR assets and generates GIF previews for a content management system.
 * 5. When you need to check pixel‑level alpha values after blurring to ensure no unintended opacity was introduced before publishing the image.
 */
