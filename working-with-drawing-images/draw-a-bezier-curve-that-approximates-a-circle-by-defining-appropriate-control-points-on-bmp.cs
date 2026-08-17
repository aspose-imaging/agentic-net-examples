// HOW-TO: Draw a Circle Using Bezier Curves on BMP with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\circle.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 2);

                // Circle parameters
                float cx = 250f;
                float cy = 250f;
                float r = 200f;
                float k = 0.5522847498f * r; // Control point offset

                // Right to Top
                graphics.DrawBezier(pen,
                    new Point((int)(cx + r), (int)cy),
                    new Point((int)(cx + r), (int)(cy - k)),
                    new Point((int)(cx + k), (int)(cy - r)),
                    new Point((int)cx, (int)(cy - r)));

                // Top to Left
                graphics.DrawBezier(pen,
                    new Point((int)cx, (int)(cy - r)),
                    new Point((int)(cx - k), (int)(cy - r)),
                    new Point((int)(cx - r), (int)(cy - k)),
                    new Point((int)(cx - r), (int)cy));

                // Left to Bottom
                graphics.DrawBezier(pen,
                    new Point((int)(cx - r), (int)cy),
                    new Point((int)(cx - r), (int)(cy + k)),
                    new Point((int)(cx - k), (int)(cy + r)),
                    new Point((int)cx, (int)(cy + r)));

                // Bottom to Right
                graphics.DrawBezier(pen,
                    new Point((int)cx, (int)(cy + r)),
                    new Point((int)(cx + k), (int)(cy + r)),
                    new Point((int)(cx + r), (int)(cy + k)),
                    new Point((int)(cx + r), (int)cy));

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
 * 1. When a developer needs to generate a high‑resolution BMP file containing a mathematically precise circle for use in engineering diagrams or printable assets, this code creates the shape with Bezier curves.
 * 2. When an application must programmatically render vector‑style graphics such as circular icons or gauges directly onto a bitmap without relying on external image editors, the example shows how to draw them with Aspose.Imaging.
 * 3. When a reporting tool requires dynamically generated circular charts or progress indicators embedded in BMP images for legacy systems that only accept BMP format, this approach provides a simple C# solution.
 * 4. When a game or simulation needs to create texture assets on the fly, such as circular masks or collision boundaries, the code demonstrates how to draw them using Bezier control points.
 * 5. When a developer is learning how to use Aspose.Imaging’s Graphics API to manipulate pixels, colors, and pens while approximating geometric shapes, this sample serves as a practical tutorial.
 */
