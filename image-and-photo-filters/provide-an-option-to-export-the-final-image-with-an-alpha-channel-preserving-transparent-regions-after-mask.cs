// HOW-TO: Apply PNG Mask While Preserving Transparency In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string maskPath = "mask.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            if (!File.Exists(maskPath))
            {
                Console.Error.WriteLine($"File not found: {maskPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            using (RasterImage mask = (RasterImage)Image.Load(maskPath))
            {
                var maskingOptions = new MaskingOptions
                {
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    }
                };

                ImageMasking.ApplyMask(source, mask, maskingOptions);
                source.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to combine a foreground PNG with a custom shape mask while keeping the original transparent areas intact for web graphics.
 * 2. When generating product thumbnails that require a non‑rectangular mask but must retain alpha transparency for overlay in UI designs.
 * 3. When preparing assets for game development where sprites are masked and the resulting PNG must preserve per‑pixel opacity.
 * 4. When automating batch processing of logo images to apply corporate mask shapes without losing the logo’s transparent background.
 * 5. When creating printable PDFs that embed masked PNG images and require the alpha channel to remain for accurate color rendering.
 */
