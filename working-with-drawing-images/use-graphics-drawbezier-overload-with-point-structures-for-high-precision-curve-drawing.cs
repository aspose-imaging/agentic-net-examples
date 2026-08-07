using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\bezier_output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options (no source stream needed for creation)
            PngOptions pngOptions = new PngOptions();

            // Create a new 500x500 image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Fill background with white
                graphics.Clear(Color.White);

                // Define a blue pen with width 2
                Pen pen = new Pen(Color.Blue, 2);

                // Define four points for the Bezier curve using Point structures
                Point pt1 = new Point(50, 400);   // start point
                Point pt2 = new Point(150, 50);   // first control point
                Point pt3 = new Point(350, 350);  // second control point
                Point pt4 = new Point(450, 100);  // end point

                // Draw the Bezier spline using the Point overload
                graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);

                // Save the image to the specified output path
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a PNG badge with a smooth curved banner for a marketing email, they can use DrawBezier with Point structures to draw the precise curve.
 * 2. When creating a custom data‑visualization chart that requires a smooth spline between data points, the code can render the curve onto a 500×500 image for export as PNG.
 * 3. When implementing a signature capture feature that stores the pen strokes as high‑precision Bezier curves, the DrawBezier overload lets the app render the signature to a PNG file.
 * 4. When designing a game UI overlay that includes decorative curved lines, developers can use the Point‑based DrawBezier call to draw anti‑aliased curves on a transparent PNG background.
 * 5. When automating the production of printable vector‑style diagrams (e.g., flowchart connectors) in a .NET service, the code provides a simple way to draw accurate Bezier segments and save them as PNG images.
 */