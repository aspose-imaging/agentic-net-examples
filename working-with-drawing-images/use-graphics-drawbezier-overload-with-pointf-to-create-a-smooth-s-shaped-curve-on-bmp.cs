using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\s_curve.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BMP image with desired dimensions
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics surface
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define pen for drawing
                Pen pen = new Pen(Color.Blue, 2);

                // Define points for an S‑shaped Bézier curve
                PointF pt1 = new PointF(50, 250);   // start point
                PointF pt2 = new PointF(150, 50);   // first control point
                PointF pt3 = new PointF(350, 450);  // second control point
                PointF pt4 = new PointF(450, 250);  // end point

                // Draw the Bézier curve using PointF overload
                graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);

                // Save the image to the specified path
                image.Save(outputPath);
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
 * 1. When a developer needs to generate a 24‑bit BMP signature stamp with a smooth S‑shaped curve for branding in a desktop C# application using Aspose.Imaging.
 * 2. When creating custom vector‑based icons in a .NET tool that must be drawn with Graphics.DrawBezier and saved as BMP files without relying on external graphic editors.
 * 3. When programmatically drawing flow‑chart connectors that require an S‑curve to improve readability in automatically generated diagrams using PointF coordinates.
 * 4. When producing test images that contain precise Bézier paths to validate image‑processing algorithms such as edge detection in Aspose.Imaging for .NET.
 * 5. When building a C# utility that renders smooth curve overlays on scanned documents and saves the result as a BMP for compatibility with legacy systems.
 */