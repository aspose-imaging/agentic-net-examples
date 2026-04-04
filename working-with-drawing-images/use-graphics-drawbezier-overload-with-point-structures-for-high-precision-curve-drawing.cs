using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\bezier_output.png";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a PNG image of size 500x500
        var pngOptions = new PngOptions();
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics object for drawing
            var graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Define four points for the Bezier curve using Point structures
            var pt1 = new Point(50, 400);   // Start point
            var pt2 = new Point(150, 50);   // First control point
            var pt3 = new Point(350, 50);   // Second control point
            var pt4 = new Point(450, 400);  // End point

            // Create a blue pen with width 3
            var pen = new Pen(Color.Blue, 3);

            // Draw the Bezier spline using the Point overload
            graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);

            // Save the image to the specified output path
            image.Save(outputPath);
        }
    }
}