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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage inputImage = (RasterImage)Image.Load(inputPath))
            {
                Source source = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = source };

                using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, inputImage.Width, inputImage.Height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawImage(inputImage, new Point(0, 0));
                    canvas.Save();
                }
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
 * 1. When a developer needs to overlay a transparent PNG logo onto a background image while preserving the logo’s alpha channel, they can use Aspose.Imaging’s Graphics with SourceOver compositing to blend the two raster images.
 * 2. When creating a composite thumbnail that combines a product photo with a promotional badge, the SourceOver mode ensures the badge is drawn on top of the photo without erasing its underlying pixels.
 * 3. When generating watermarked PDFs by rendering vector‑based watermark graphics onto each page image, SourceOver blending lets the watermark appear semi‑transparent over the original content.
 * 4. When building a photo‑editing tool that lets users add stickers or emojis to pictures, using Graphics.DrawImage with SourceOver merges the sticker’s pixels with the base image while respecting transparency.
 * 5. When automating the preparation of UI assets by compositing multiple PNG layers (background, icons, text) into a single image for mobile apps, SourceOver ensures each layer blends correctly without losing detail.
 */