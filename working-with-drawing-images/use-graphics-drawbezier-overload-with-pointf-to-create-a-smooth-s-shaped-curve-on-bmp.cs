using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Canvas size
            int width = 500;
            int height = 500;

            // BMP options with bound file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Pen for the S‑shaped curve
                Pen pen = new Pen(Color.Blue, 3);

                // Define points for the S‑curve using PointF
                PointF pt1 = new PointF(100, 400); // start
                PointF pt2 = new PointF(150, 100); // first control
                PointF pt3 = new PointF(350, 400); // second control
                PointF pt4 = new PointF(400, 100); // end

                // Draw the Bezier curve
                graphics.DrawBezier(pen, pt1, pt2, pt3, pt4);

                // Save the image (file is already bound)
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
 * 1. When a developer needs to generate a BMP signature image with a smooth S‑shaped curve for a custom watermark, they can use Aspose.Imaging’s Graphics.DrawBezier overload with PointF coordinates.
 * 2. When creating a printable schematic in C# that requires a precise S‑curve path, such as a road layout diagram saved as a BMP file, the code demonstrates how to draw it with a blue pen.
 * 3. When building an automated report generator that embeds decorative S‑shaped separators in BMP charts, the DrawBezier method with PointF provides pixel‑accurate control over the curve shape.
 * 4. When developing a game asset pipeline that programmatically creates BMP textures containing fluid‑like S‑curves for UI elements, this example shows how to render the curve and save it directly to disk.
 * 5. When implementing a scientific visualization tool that needs to illustrate S‑shaped data trends in a BMP image without external graphics libraries, the code illustrates using Aspose.Imaging’s Graphics and Pen classes to draw the curve.
 */