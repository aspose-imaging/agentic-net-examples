// HOW-TO: Apply Gaussian Blur and Resize CDR to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "Output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions rasterOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, rasterOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));
                        raster.Resize(1200, 800);

                        PngOptions saveOptions = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };
                        raster.Save(outputPath, saveOptions);
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
 * 1. When you need to convert a CorelDRAW (CDR) illustration to a web‑ready PNG while softening the image with a Gaussian blur.
 * 2. When an automated workflow must batch‑process CDR files, apply a blur effect, and generate thumbnails of 1200×800 pixels for a gallery.
 * 3. When integrating Aspose.Imaging into a C# application to rasterize vector CDR pages, apply smoothing, and output high‑quality PNGs for printing.
 * 4. When preparing product mockups by blurring background elements of a CDR design and resizing it to fit a marketing banner.
 * 5. When a server‑side service has to receive CDR uploads, apply a blur filter for privacy, resize the image, and store it as PNG for downstream consumption.
 */
