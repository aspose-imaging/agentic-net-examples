// HOW-TO: Deskew PSD, Increase Brightness and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
        string outputPath = "output.png";

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
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.NormalizeAngle(false, Color.White);
                raster.AdjustBrightness(30);

                PngOptions pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to correct a scanned Photoshop file that is slightly rotated, enhance its visibility, and deliver it as a web‑friendly PNG using C#.
 * 2. When an automated workflow must straighten product mockups saved as PSD, brighten them for better contrast, and store the results in PNG for downstream processing.
 * 3. When a batch job processes user‑uploaded PSD designs, removes tilt, adjusts lighting, and converts them to PNG thumbnails for a gallery.
 * 4. When a desktop application has to import a tilted PSD layer, improve its brightness, and export the final image in PNG format for printing or sharing.
 * 5. When integrating Aspose.Imaging into a C# service that normalizes angle, boosts brightness, and converts PSD assets to PNG for mobile app consumption.
 */
