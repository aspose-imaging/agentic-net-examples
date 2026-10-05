// HOW-TO: Remove SVG Background While Keeping White Elements and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
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
                var vectorImage = image as VectorImage;
                if (vectorImage != null)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = image.Size
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
 * 1. When you need to strip the background from an SVG logo but keep white text or shapes intact before exporting to a PNG for web use.
 * 2. When generating product thumbnails from vector artwork and you want a transparent PNG without losing white foreground details.
 * 3. When automating batch conversion of SVG icons to PNG assets for a mobile app, ensuring the icons retain their white elements on a clear background.
 * 4. When preparing vector diagrams for inclusion in a PDF report and you must remove the original background while preserving white lines and labels.
 * 5. When cleaning up scanned vector graphics that contain a solid background, and you need to programmatically make the background transparent while keeping white graphics visible.
 */
