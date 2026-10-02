// HOW-TO: Convert CMX Drawing to Transparent PNG with Alpha Channel in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = cmx.Size
                    }
                };

                cmx.Save(outputPath, pngOptions);
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
 * 1. When you need to display a CorelDRAW CMX vector graphic on a website and require a PNG with a transparent background so it blends with the page design.
 * 2. When you are generating thumbnails of CMX drawings for a mobile app and want the images to retain alpha transparency for overlay effects.
 * 3. When you are converting legacy CMX assets to a modern format for a UI that supports PNG with alpha, ensuring the original background color does not obscure underlying elements.
 * 4. When you automate batch processing of CMX files to create transparent PNG icons for a software product’s toolbar.
 * 5. When you integrate Aspose.Imaging into a C# service that receives CMX files and must return PNGs with transparent backgrounds for downstream image‑processing pipelines.
 */
