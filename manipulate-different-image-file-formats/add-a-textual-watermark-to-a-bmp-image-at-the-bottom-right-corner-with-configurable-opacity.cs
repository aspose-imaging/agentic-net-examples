using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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
                var graphics = new Graphics(image);

                string watermarkText = "Sample Watermark";
                var font = new Font("Arial", 24);
                using (var brush = new SolidBrush())
                {
                    brush.Color = Color.White;
                    brush.Opacity = 0.5f;

                    var textSize = graphics.MeasureString(watermarkText, font, new SizeF(image.Width, image.Height), null);

                    float margin = 10f;
                    float x = image.Width - textSize.Width - margin;
                    float y = image.Height - textSize.Height - margin;

                    graphics.DrawString(watermarkText, font, brush, new PointF(x, y));
                }

                image.Save(outputPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}