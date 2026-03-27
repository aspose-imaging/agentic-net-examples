using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Configurable opacity (0 = fully transparent, 1 = fully opaque)
        float opacity = 0.5f;

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (var image = Image.Load(inputPath))
        {
            var bmpImage = (BmpImage)image;

            // Create a Graphics instance for drawing
            Graphics graphics = new Graphics(bmpImage);

            // Prepare brush with desired opacity
            using (var brush = new SolidBrush())
            {
                brush.Color = Color.White;
                brush.Opacity = opacity;

                // Define font and watermark text
                Font font = new Font("Arial", 24);
                string text = "Sample Watermark";

                // Measure text size
                var layoutArea = new SizeF(bmpImage.Width, bmpImage.Height);
                var stringFormat = new StringFormat();
                var textSize = graphics.MeasureString(text, font, layoutArea, stringFormat);

                // Position at bottom-right with a margin
                int margin = 10;
                float x = bmpImage.Width - textSize.Width - margin;
                float y = bmpImage.Height - textSize.Height - margin;

                // Draw the watermark text
                graphics.DrawString(text, font, brush, new PointF(x, y));
            }

            // Save the modified image as BMP
            bmpImage.Save(outputPath, new BmpOptions());
        }
    }
}