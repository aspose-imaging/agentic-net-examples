using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\bezier_circle.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file stream source
            BmpOptions bmpOptions = new BmpOptions();
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                bmpOptions.Source = new StreamSource(stream);

                // Create a 400x400 image canvas
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 400, 400))
                {
                    // Initialize graphics for drawing
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    // Pen for the Bezier curve
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);

                    // Parameters for a circle approximation
                    float radius = 150f;
                    float c = 0.5522847498f * radius; // Control point offset

                    // First quarter
                    graphics.DrawBezier(pen,
                        new Aspose.Imaging.PointF(200 + radius, 200),
                        new Aspose.Imaging.PointF(200 + radius, 200 + c),
                        new Aspose.Imaging.PointF(200 + c, 200 + radius),
                        new Aspose.Imaging.PointF(200, 200 + radius));

                    // Second quarter
                    graphics.DrawBezier(pen,
                        new Aspose.Imaging.PointF(200, 200 + radius),
                        new Aspose.Imaging.PointF(200 - c, 200 + radius),
                        new Aspose.Imaging.PointF(200 - radius, 200 + c),
                        new Aspose.Imaging.PointF(200 - radius, 200));

                    // Third quarter
                    graphics.DrawBezier(pen,
                        new Aspose.Imaging.PointF(200 - radius, 200),
                        new Aspose.Imaging.PointF(200 - radius, 200 - c),
                        new Aspose.Imaging.PointF(200 - c, 200 - radius),
                        new Aspose.Imaging.PointF(200, 200 - radius));

                    // Fourth quarter
                    graphics.DrawBezier(pen,
                        new Aspose.Imaging.PointF(200, 200 - radius),
                        new Aspose.Imaging.PointF(200 + c, 200 - radius),
                        new Aspose.Imaging.PointF(200 + radius, 200 - c),
                        new Aspose.Imaging.PointF(200 + radius, 200));

                    // Save the image
                    image.Save();
                }
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
 * 1. When a developer needs to generate a high‑resolution BMP icon that contains a perfect‑looking circular button using only vector drawing commands, they can use this code to approximate the circle with Bezier curves.
 * 2. When creating automated test images for a graphics pipeline that expects BMP files with precise geometric shapes, this snippet provides a reproducible way to draw a circle without relying on external assets.
 * 3. When building a PDF or report generator that embeds raster graphics of circular logos, the code can render the logo into a BMP stream with Aspose.Imaging before embedding.
 * 4. When a game or UI tool requires pre‑rendered circular sprites stored as BMP files for legacy hardware, developers can programmatically produce them with the Bezier‑based circle routine.
 * 5. When implementing a batch image‑processing job that adds a circular watermark to existing BMP photos, the example shows how to draw the circle directly onto a new BMP canvas using C# and Aspose.Imaging.
 */