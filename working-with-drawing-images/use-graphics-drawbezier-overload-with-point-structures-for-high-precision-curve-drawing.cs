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

            // Create a new PNG image (500x500)
            PngOptions pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define a blue pen
                Pen pen = new Pen(Color.Blue, 2);

                // Define four points for the Bezier curve
                Point pt1 = new Point(50, 400);   // start point
                Point pt2 = new Point(150, 50);   // first control point
                Point pt3 = new Point(350, 350);  // second control point
                Point pt4 = new Point(450, 100);  // end point

                // Draw the Bezier curve using Point overload
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
 * 1. When creating a custom PNG logo that requires smooth, high‑precision curves, a developer can use DrawBezier with Point structures to draw the bezier path and then save the image with PngOptions.
 * 2. When generating dynamic chart annotations such as trend lines or spline curves in a 500×500 PNG report, the code lets a C# application render the curve precisely and embed it in the final document.
 * 3. When building a web service that returns on‑the‑fly generated graphics (e.g., signature pads or decorative separators) as PNG files, the DrawBezier overload provides pixel‑accurate control over the curve shape.
 * 4. When automating the creation of printable vector‑style graphics for marketing materials, developers can define exact start, control, and end points to ensure the bezier curve matches design specifications before saving the PNG.
 * 5. When implementing a game UI overlay that needs to draw smooth paths for motion trails or UI elements in a .NET application, the code demonstrates how to render the curve with a blue pen and export it as a PNG asset.
 */