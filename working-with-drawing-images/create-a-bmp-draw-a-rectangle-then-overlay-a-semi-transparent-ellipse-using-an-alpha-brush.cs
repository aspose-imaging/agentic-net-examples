// HOW-TO: Generate BMP Image With Blue Rectangle And 50% Transparent Red Ellipse In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"c:\temp\output.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Draw a rectangle
                Aspose.Imaging.Pen rectPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
                graphics.DrawRectangle(rectPen, new Aspose.Imaging.Rectangle(50, 50, 300, 200));

                // Overlay a semi‑transparent ellipse
                using (SolidBrush ellipseBrush = new SolidBrush())
                {
                    ellipseBrush.Color = Aspose.Imaging.Color.Red;
                    ellipseBrush.Opacity = 0.5f; // 50% opacity
                    graphics.FillEllipse(ellipseBrush, new Aspose.Imaging.Rectangle(100, 80, 200, 150));
                }

                // Save the image
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
 * 1. When you need to programmatically create a BMP file for a legacy system and draw basic shapes like a rectangle and a semi‑transparent ellipse.
 * 2. When you want to add a watermark‑style overlay with adjustable opacity to an image generated on the fly in a C# desktop application.
 * 3. When you are building a reporting tool that renders simple graphics such as charts or diagrams directly to BMP without using external design software.
 * 4. When you must produce a 24‑bit BMP for printing devices that only accept that format and require custom shape annotations.
 * 5. When you are testing image‑processing pipelines and need a deterministic BMP sample containing both stroked and filled shapes with alpha blending.
 */
