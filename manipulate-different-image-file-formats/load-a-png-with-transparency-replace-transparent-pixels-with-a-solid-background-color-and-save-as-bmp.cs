// HOW-TO: Replace Transparent Pixels in PNG with Solid Background and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                for (int i = 0; i < pixels.Length; i++)
                {
                    int argb = pixels[i];
                    if ((argb >> 24) == 0)
                    {
                        pixels[i] = unchecked((int)0xFFFFFFFF);
                    }
                }
                raster.SaveArgb32Pixels(raster.Bounds, pixels);

                Source outSource = new FileCreateSource(outputPath, false);
                BmpOptions bmpOptions = new BmpOptions() { Source = outSource };
                raster.Save(outputPath, bmpOptions);
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
 * 1. When you need to convert a PNG logo with transparent areas into a BMP for legacy Windows applications that do not support alpha channels.
 * 2. When preparing images for printing where the printer driver requires a solid background instead of transparent pixels.
 * 3. When generating thumbnails for a report and the target format (BMP) must have a white background to ensure consistent appearance.
 * 4. When batch‑processing user‑uploaded PNG icons to embed them in a game asset pipeline that only accepts BMP files without transparency.
 * 5. When integrating Aspose.Imaging in a C# service that sanitizes images by removing alpha transparency before storing them in a BMP‑based archive.
 */
