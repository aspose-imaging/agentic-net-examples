using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    graphics.FillRectangle(brush, new Rectangle(50, 50, 200, 150));
                }

                PngOptions options = new PngOptions { Source = new FileCreateSource(outputPath, false) };
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
 * 1. When a developer wants to overlay a semi‑transparent red warning box on an existing PNG screenshot for a web‑app dashboard.
 * 2. When a developer needs to add a translucent watermark rectangle to product photos before uploading them to an e‑commerce site.
 * 3. When a developer creates a custom UI theme by drawing semi‑opaque shapes on a base PNG icon to generate different button states.
 * 4. When a developer generates a report thumbnail that highlights a region of interest by blending a colored rectangle over the original image.
 * 5. When a developer prepares marketing assets by compositing promotional graphics onto a background PNG while preserving the underlying pixel data.
 */