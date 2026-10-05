// HOW-TO: Increase Brightness of PSD and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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

            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage raster)
                {
                    raster.AdjustBrightness(50);
                }

                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to brighten a Photoshop PSD file before displaying it as a lightweight PNG thumbnail.
 * 2. When an automated batch process must enhance the visibility of dark layers in PSD assets and export them to PNG for use in mobile apps.
 * 3. When a digital asset management system requires converting user‑uploaded PSD files to PNG while applying a brightness boost to meet branding guidelines.
 * 4. When a reporting tool generates PNG charts from PSD templates and needs to increase brightness to improve readability on projector screens.
 * 5. When a cloud service processes PSD images, adjusts their brightness to compensate for low‑light scans, and stores the result as PNG for downstream processing.
 */
