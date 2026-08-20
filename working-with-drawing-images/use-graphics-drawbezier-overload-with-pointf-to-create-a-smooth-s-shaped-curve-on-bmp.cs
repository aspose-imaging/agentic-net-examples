// HOW-TO: Draw Smooth S Shaped Bezier Curve on BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"output\s_curve.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Define the S‑shaped Bezier curve points
                Aspose.Imaging.PointF pt1 = new Aspose.Imaging.PointF(50f, 250f);   // start
                Aspose.Imaging.PointF pt2 = new Aspose.Imaging.PointF(150f, 50f);   // control 1
                Aspose.Imaging.PointF pt3 = new Aspose.Imaging.PointF(350f, 450f);  // control 2
                Aspose.Imaging.PointF pt4 = new Aspose.Imaging.PointF(450f, 250f);  // end

                // Draw the curve using a blue pen
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
                graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);

                // Save the image (output path already bound)
                image.Save();
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
 * 1. When you need to programmatically generate a BMP file that contains a custom S‑shaped curve for a diagram or illustration in a .NET application.
 * 2. When creating dynamic graphics for reports, such as a smooth flow‑line that visualizes data movement and must be saved as a BMP image.
 * 3. When building a simple drawing tool that lets users add stylized Bezier curves to a canvas and export the result in BMP format.
 * 4. When generating placeholder graphics for UI mockups where a specific S‑curve shape is required to represent a connector or pathway.
 * 5. When automating the production of test images that contain precise vector shapes to validate image‑processing pipelines in C#.
 */
