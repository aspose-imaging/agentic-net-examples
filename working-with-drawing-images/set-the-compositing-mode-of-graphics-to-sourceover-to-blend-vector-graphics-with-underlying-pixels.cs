using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

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

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 0, 0, 255)))
                {
                    graphics.FillRectangle(brush, 50, 50, 200, 100);
                }

                PngOptions options = new PngOptions();
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
 * 1. When a developer wants to add a semi‑transparent PNG watermark or logo on top of an existing image, using Graphics with SourceOver compositing blends the overlay smoothly with the underlying pixels.
 * 2. When generating dynamic report charts in a C# web application, setting the compositing mode to SourceOver lets vector shapes like bars or lines be drawn over a background image without erasing its details.
 * 3. When creating custom UI skins for a Windows Forms app, a developer can render translucent button highlights on a PNG asset by filling rectangles with an ARGB brush and SourceOver blending.
 * 4. When processing scanned documents and need to highlight selected regions with a colored overlay, using Graphics.SourceOver ensures the highlight color mixes with the original scan while preserving readability.
 * 5. When building an image‑based email template generator, a developer can overlay semi‑transparent promotional banners on product photos, relying on SourceOver compositing to maintain the photo’s original colors and texture.
 */