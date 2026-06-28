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
                var graphics = new Graphics(bmpImage);

                string watermarkText = "Sample Watermark";
                float opacity = 0.5f;
                int margin = 10;

                using (var brush = new SolidBrush())
                {
                    brush.Color = Color.White;
                    brush.Opacity = opacity;

                    var font = new Font("Arial", 24);

                    var layoutArea = new SizeF(bmpImage.Width, bmpImage.Height);
                    var format = new StringFormat();
                    var textSize = graphics.MeasureString(watermarkText, font, layoutArea, format);

                    float x = bmpImage.Width - textSize.Width - margin;
                    float y = bmpImage.Height - textSize.Height - margin;

                    graphics.DrawString(watermarkText, font, brush, new PointF(x, y));
                }

                var bmpOptions = new BmpOptions();
                bmpImage.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to embed a semi‑transparent copyright watermark onto BMP screenshots using C# before sending them to clients.
 * 2. When an application must automatically add a “Confidential” textual watermark with configurable opacity to scanned BMP documents to deter unauthorized distribution.
 * 3. When a game studio wants to tag BMP texture assets with version numbers in the lower‑right corner during the build pipeline, using Aspose.Imaging for .NET.
 * 4. When a batch‑processing tool has to place a customizable brand name watermark on BMP product images for e‑commerce listings, controlling the opacity and margin via code.
 * 5. When a security system requires adding a timestamp watermark to BMP surveillance frames at the bottom‑right, with adjustable opacity to keep the overlay readable yet unobtrusive.
 */