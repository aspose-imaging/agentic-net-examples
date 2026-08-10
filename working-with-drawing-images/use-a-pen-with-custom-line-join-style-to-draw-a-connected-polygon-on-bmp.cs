// HOW-TO: Draw Polygon With Custom Line Join On BMP Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image with desired dimensions
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.Wheat);

                // Create a pen with custom line join style
                Pen pen = new Pen(Color.Blue, 5);
                pen.LineJoin = LineJoin.Bevel; // Custom line join

                // Define polygon points (connected shape)
                Point[] polygonPoints = new Point[]
                {
                    new Point(50, 50),
                    new Point(350, 50),
                    new Point(350, 350),
                    new Point(50, 350)
                };

                // Draw the polygon
                graphics.DrawPolygon(pen, polygonPoints);

                // Save the image (output path already set in options)
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
 * 1. When you need to generate a 400×400 BMP report graphic that highlights a rectangular area with a blue beveled outline.
 * 2. When creating custom UI icons or thumbnails in C# where the polygon edges require a specific line‑join style such as bevel.
 * 3. When automating batch production of map overlays and you must draw land‑parcel boundaries with consistent stroke thickness on a BMP background.
 * 4. When building a server‑side image service that returns BMP images with highlighted zones and you want to control how corner joins appear.
 * 5. When prototyping a diagramming tool and need to quickly render connected shapes with Aspose.Imaging while specifying line join behavior.
 */
