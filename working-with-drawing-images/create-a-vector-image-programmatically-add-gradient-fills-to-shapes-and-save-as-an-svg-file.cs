using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output SVG file path (hardcoded)
            string outputPath = "output/output.svg";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define canvas size and DPI
            int width = 600;
            int height = 400;
            int dpi = 96;

            // Create an SVG graphics canvas
            var graphics = new SvgGraphics2D(width, height, dpi);

            // Solid fill for a rectangle
            using (var solidBrush = new SolidBrush(Color.Red))
            {
                var rectPen = new Pen(Color.Black, 1);
                graphics.FillRectangle(rectPen, solidBrush, 50, 50, 200, 150);
            }

            // Solid fill for a shape (using rectangle as placeholder)
            using (var solidBrush2 = new SolidBrush(Color.Green))
            {
                var shapePen = new Pen(Color.DarkGreen, 2);
                graphics.DrawRectangle(shapePen, 300, 100, 200, 200);
                graphics.FillRectangle(shapePen, solidBrush2, 300, 100, 200, 200);
            }

            // Finalize and save the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                svgImage.Save(outputPath);
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
 * 1. When a web developer needs to generate a scalable SVG diagram with custom colors and DPI on the server side, they can use Aspose.Imaging in C# to draw shapes and save the vector image as an SVG file.
 * 2. When an automated reporting tool must embed dynamically created vector icons with solid or gradient fills into HTML or PDF reports, this code shows how to programmatically create and export the SVG assets.
 * 3. When a desktop application requires on‑the‑fly creation of printable badges or labels that include rectangles with precise stroke and fill properties, developers can use the SvgGraphics2D canvas to render and save the SVG.
 * 4. When a game or simulation engine needs to export level maps or UI components as resolution‑independent SVG files for vector‑based rendering, the example demonstrates the C# workflow with Aspose.Imaging.
 * 5. When a CI/CD pipeline needs to verify that generated SVG graphics meet branding color specifications by programmatically drawing shapes with specific brushes, this snippet provides a repeatable method to produce the SVG output.
 */