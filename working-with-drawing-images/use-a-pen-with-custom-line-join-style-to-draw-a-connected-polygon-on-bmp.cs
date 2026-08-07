using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string outputPath = @"C:\temp\polygon.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 400x400 BMP image
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a pen with custom line join style
                Pen pen = new Pen(Color.Blue, 5f);
                pen.LineJoin = LineJoin.Round; // Custom join style

                // Define polygon points
                Point[] points = new Point[]
                {
                    new Point(50, 50),
                    new Point(350, 50),
                    new Point(350, 350),
                    new Point(50, 350)
                };

                // Draw the polygon
                graphics.DrawPolygon(pen, points);

                // Save the image (file is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a 400 × 400 BMP file with a blue polygon whose corners are smoothly connected using a round line join for use in a Windows desktop UI.
 * 2. When an application must programmatically create a printable bitmap badge and require precise control over line thickness and join style to ensure the polygon border looks consistent across printers.
 * 3. When a reporting tool has to embed a simple vector‑style shape into a BMP chart and the developer wants to use Aspose.Imaging’s Pen object to set a custom LineJoin for aesthetic corners.
 * 4. When an automated image‑processing pipeline needs to add a rectangular outline to a blank canvas and must guarantee the output file is saved directly to a specified path without intermediate streams.
 * 5. When a game‑level editor written in C# must export level boundaries as a BMP image and wants to use the DrawPolygon method with a round join to avoid sharp angles that could cause visual artifacts.
 */