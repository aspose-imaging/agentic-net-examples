// HOW-TO: Deskew PSD Image, Increase Brightness and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.NormalizeAngle(false, Aspose.Imaging.Color.White);
                raster.AdjustBrightness(50);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to correct the rotation of a scanned Photoshop file, brighten it for better visibility, and deliver the result as a web‑ready PNG.
 * 2. When an automated workflow must preprocess PSD assets by straightening them, adjusting exposure, and converting them to PNG for downstream publishing systems.
 * 3. When a desktop application imports user‑provided PSD files, normalizes their angle, enhances the lighting, and stores the edited picture in PNG format for display.
 * 4. When a batch script processes a folder of PSD designs, removes skew, boosts brightness, and generates PNG thumbnails for a catalog.
 * 5. When a server‑side service receives PSD uploads, needs to deskew and brighten the image before saving it as PNG for API consumers.
 */
