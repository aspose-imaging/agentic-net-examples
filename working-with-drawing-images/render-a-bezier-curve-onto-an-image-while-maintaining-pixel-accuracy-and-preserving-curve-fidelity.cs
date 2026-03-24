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
        string outputPath = @"C:\temp\bezier_output.png";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a PNG image with the desired dimensions
        var pngOptions = new PngOptions();
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics object for drawing
            var graphics = new Graphics(image);

            // Clear the canvas with a white background
            graphics.Clear(Color.White);

            // Define a blue pen with a thickness of 2 pixels
            var pen = new Pen(Color.Blue, 2);

            // Define the four points of the cubic Bézier curve
            var pt1 = new Point(50, 400);   // Start point
            var pt2 = new Point(150, 50);   // First control point
            var pt3 = new Point(350, 50);   // Second control point
            var pt4 = new Point(450, 400);  // End point

            // Draw the Bézier curve preserving pixel accuracy
            graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);

            // Save the resulting image to the hardcoded output path
            image.Save(outputPath);
        }
    }
}