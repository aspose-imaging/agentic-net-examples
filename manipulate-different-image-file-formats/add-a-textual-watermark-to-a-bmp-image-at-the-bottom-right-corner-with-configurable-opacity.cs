using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";
        float opacity = 0.5f;

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
                using (var brush = new SolidBrush(Color.White))
                {
                    brush.Opacity = opacity;

                    string watermarkText = "Sample Watermark";
                    Font font = new Font("Arial", 24);

                    Graphics graphics = new Graphics(image);

                    var textSize = graphics.MeasureString(watermarkText, font, new SizeF(image.Width, image.Height), null);
                    float margin = 10f;
                    float x = image.Width - textSize.Width - margin;
                    float y = image.Height - textSize.Height - margin;

                    graphics.DrawString(watermarkText, font, brush, new PointF(x, y));

                    image.Save(outputPath, new BmpOptions());
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
 * 1. Use this code to add a semi‑transparent text watermark to a BMP image in a C# application using Aspose.Imaging before publishing the image online.
 * 2. Use this code to embed a copyright notice in the bottom‑right corner of scanned BMP documents, adjusting the brush opacity for legal compliance.
 * 3. Use this code to generate watermarked BMP thumbnails for a desktop C# app that displays user‑uploaded images, ensuring the watermark remains readable at any size.
 * 4. Use this code to prepare BMP assets for a game, adding a developer‑defined label with configurable opacity to each sprite using Aspose.Imaging graphics.
 * 5. Use this code to automate batch processing of BMP screenshots, applying a faint brand logo at the corner with adjustable opacity via a SolidBrush.
 */