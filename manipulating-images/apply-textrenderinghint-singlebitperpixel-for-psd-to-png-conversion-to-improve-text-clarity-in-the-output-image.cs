// HOW-TO: Convert PSD to PNG with Single Bit Per Pixel Text Rendering in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.psd";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                    }
                };
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
 * 1. When you need to export a Photoshop PSD that contains vector text to a PNG while preserving crisp, pixel‑perfect text for web display.
 * 2. When generating thumbnails from PSD files and want the embedded text to remain sharp after rasterization.
 * 3. When automating a batch conversion of design assets and must ensure text readability in the resulting PNGs for print‑ready proofs.
 * 4. When creating PNG assets for a mobile app from PSD sources and need to minimize anti‑aliasing artifacts on small screens.
 * 5. When processing PSD files in a server‑side C# service and want to improve text clarity without manually adjusting each layer.
 */
