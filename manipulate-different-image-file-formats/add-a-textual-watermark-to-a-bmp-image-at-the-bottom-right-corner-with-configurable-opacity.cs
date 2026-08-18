// HOW-TO: Add Semi Transparent Text Watermark to BMP Image in C# (Aspose.Imaging for .NET)
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
                var bmpImage = (BmpImage)image;
                int width = bmpImage.Width;
                int height = bmpImage.Height;

                Graphics graphics = new Graphics(bmpImage);

                string watermarkText = "Sample Watermark";
                float opacity = 0.5f;

                Font font = new Font("Arial", 24);

                var textSize = graphics.MeasureString(
                    watermarkText,
                    font,
                    new SizeF(width, height),
                    new StringFormat());

                float margin = 10f;
                float x = width - textSize.Width - margin;
                float y = height - textSize.Height - margin;

                using (var brush = new SolidBrush())
                {
                    brush.Color = Color.White;
                    brush.Opacity = opacity;
                    graphics.DrawString(watermarkText, font, brush, new PointF(x, y));
                }

                bmpImage.Save(outputPath, new BmpOptions());
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
 * 1. When you need to protect BMP graphics with a subtle copyright notice before publishing them online.
 * 2. When you want to embed a brand name as a faint text overlay on scanned BMP documents for internal distribution.
 * 3. When you must add a timestamp or user identifier to BMP screenshots to track usage while keeping the image readable.
 * 4. When you are preparing BMP assets for a game and need to mark test versions with a low‑opacity watermark at the bottom‑right corner.
 * 5. When you are automating batch processing of BMP files and require a configurable opacity watermark for compliance reporting.
 */
