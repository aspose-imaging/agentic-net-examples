using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\Temp\ArcOutput.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PNG options
        PngOptions pngOptions = new PngOptions();

        // Create a new image with desired dimensions
        using (Image image = Image.Create(pngOptions, 500, 300))
        {
            // Initialize graphics object
            Graphics graphics = new Graphics(image);

            // Clear background (optional)
            graphics.Clear(Color.White);

            // Define the rectangle that bounds the ellipse (400x200)
            Rectangle rect = new Rectangle(50, 50, 400, 200);

            // Create a black pen with width 2
            Pen pen = new Pen(Color.Black, 2);

            // Draw the arc: start at 45 degrees, sweep 180 degrees
            graphics.DrawArc(pen, rect, 45f, 180f);

            // Save the image
            image.Save(outputPath);
        }
    }
}