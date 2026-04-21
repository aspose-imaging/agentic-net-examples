using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (var image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to RasterImage for drawing
            var raster = (Aspose.Imaging.RasterImage)image;

            // Create a Graphics instance for drawing
            var graphics = new Aspose.Imaging.Graphics(raster);

            // Configurable opacity (0 = fully transparent, 1 = fully opaque)
            float opacity = 0.5f; // example value

            // Create a solid brush with the desired opacity
            using (var brush = new SolidBrush())
            {
                brush.Color = Aspose.Imaging.Color.FromArgb(255, 255, 255, 255); // white color
                brush.Opacity = opacity;

                // Define font for the watermark text
                var font = new Aspose.Imaging.Font("Arial", 24);

                // Watermark text
                string watermarkText = "Sample Watermark";

                // Measure text size to position it at bottom‑right with a margin
                var textSize = graphics.MeasureString(
                    watermarkText,
                    font,
                    new Aspose.Imaging.SizeF(raster.Width, raster.Height),
                    null);

                int margin = 10;
                float x = raster.Width - textSize.Width - margin;
                float y = raster.Height - textSize.Height - margin;

                // Draw the watermark text
                graphics.DrawString(watermarkText, font, brush, new Aspose.Imaging.PointF(x, y));
            }

            // Save the result as BMP
            var bmpOptions = new BmpOptions();
            raster.Save(outputPath, bmpOptions);
        }
    }
}