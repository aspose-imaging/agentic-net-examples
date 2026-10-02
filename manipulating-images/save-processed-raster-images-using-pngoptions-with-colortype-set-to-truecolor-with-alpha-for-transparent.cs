// HOW-TO: Save PNG With Truecolor With Alpha Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                image.Save(outputPath, options);
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
 * 1. When you need to preserve full RGBA transparency while re‑encoding PNG images for web delivery using Aspose.Imaging in C#.
 * 2. When converting legacy PNG files to a format that guarantees truecolor with alpha for consistent rendering across browsers.
 * 3. When processing scanned graphics that require lossless saving with 24‑bit color and an 8‑bit alpha channel using Aspose.Imaging.
 * 4. When generating thumbnails of PNG assets and must keep transparent backgrounds intact during the save operation.
 * 5. When building an image pipeline that stores PNGs with TruecolorWithAlpha to ensure compatibility with design tools expecting 32‑bit PNGs.
 */
