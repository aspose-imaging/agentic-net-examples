// HOW-TO: Batch Convert BMP Folder to PNG with 10‑Pixel Crop in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

namespace BatchConvert
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "C:\\Images\\Input";
                string outputFolder = "C:\\Images\\Output";

                Directory.CreateDirectory(outputFolder);

                string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp", SearchOption.TopDirectoryOnly);
                foreach (string inputPath in bmpFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        var raster = image as RasterImage;
                        if (raster == null)
                        {
                            Console.Error.WriteLine($"Unsupported image format: {inputPath}");
                            continue;
                        }

                        int newWidth = raster.Width - 20;
                        int newHeight = raster.Height - 20;
                        if (newWidth <= 0 || newHeight <= 0)
                        {
                            Console.Error.WriteLine($"Image too small to crop: {inputPath}");
                            continue;
                        }

                        var cropRect = new Rectangle(10, 10, newWidth, newHeight);
                        raster.Crop(cropRect);

                        var pngOptions = new PngOptions();
                        raster.Save(outputPath, pngOptions);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to prepare a large set of legacy BMP screenshots for a web gallery by removing a uniform border and converting them to PNG for smaller file size.
 * 2. When an automated build process must generate PNG assets from BMP design files while trimming a 10‑pixel margin to align with UI layout requirements.
 * 3. When a migration script has to replace BMP icons with lossless PNG equivalents and ensure each image is cropped consistently before deployment.
 * 4. When a data‑import routine reads BMP scans, removes the outer edge, and stores the result as PNG for downstream image‑analysis tools.
 * 5. When a desktop application must batch‑process user‑uploaded BMP photos, crop a fixed border, and save them as PNG for consistent cross‑platform display.
 */
