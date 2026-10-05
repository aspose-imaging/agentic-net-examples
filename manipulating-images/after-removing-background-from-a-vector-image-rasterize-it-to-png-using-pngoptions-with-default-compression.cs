// HOW-TO: Remove Background From SVG and Convert To PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.svg";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = image.Size
                    }
                };

                var vectorImage = image as VectorImage;
                if (vectorImage != null)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }

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
 * 1. When you need to generate transparent PNG thumbnails from SVG logos for web pages.
 * 2. When an e‑commerce platform must strip the background from product vector illustrations before displaying them in a catalog.
 * 3. When a mobile app requires converting user‑uploaded SVG icons to PNG assets with an alpha channel for UI rendering.
 * 4. When a reporting tool has to embed vector diagrams as PNG images with no background in PDF reports.
 * 5. When a content management system automates the preparation of SVG artwork for social media by removing backgrounds and rasterizing to PNG.
 */
