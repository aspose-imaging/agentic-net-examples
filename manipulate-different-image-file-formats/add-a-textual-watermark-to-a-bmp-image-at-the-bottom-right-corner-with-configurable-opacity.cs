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
        float opacity = 0.5f; // Opacity between 0 (transparent) and 1 (opaque)

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
                var raster = (RasterImage)image;

                // Create graphics for drawing
                Graphics graphics = new Graphics(raster);

                // Prepare brush with configurable opacity
                using (var brush = new SolidBrush(Aspose.Imaging.Color.White))
                {
                    brush.Opacity = opacity;

                    // Font for the watermark text
                    var font = new Font("Arial", 24);

                    // Watermark text
                    string watermarkText = "Sample Watermark";

                    // Measure text size to position it at bottom‑right
                    var textSize = graphics.MeasureString(watermarkText, font, new SizeF(raster.Width, raster.Height), null);
                    float margin = 10f;
                    float x = raster.Width - textSize.Width - margin;
                    float y = raster.Height - textSize.Height - margin;

                    // Draw the watermark
                    graphics.DrawString(watermarkText, font, brush, new PointF(x, y));
                }

                // Save the result as BMP
                var bmpOptions = new BmpOptions();
                raster.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}