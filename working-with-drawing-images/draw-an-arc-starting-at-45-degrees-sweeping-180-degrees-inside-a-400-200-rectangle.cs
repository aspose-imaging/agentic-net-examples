using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\arc_output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PNG options
        var pngOptions = new PngOptions();

        // Create a new image with desired dimensions
        using (Image image = Image.Create(pngOptions, 500, 300))
        {
            // Initialize graphics for drawing
            var graphics = new Graphics(image);

            // Optional: clear background
            graphics.Clear(Color.White);

            // Define pen for the arc
            var pen = new Pen(Color.Black, 2);

            // Define rectangle (x, y, width, height) where the arc will be drawn
            var rect = new Rectangle(50, 50, 400, 200);

            // Draw arc starting at 45 degrees, sweeping 180 degrees
            graphics.DrawArc(pen, rect, 45, 180);

            // Save the image to the specified path
            image.Save(outputPath);
        }
    }
}