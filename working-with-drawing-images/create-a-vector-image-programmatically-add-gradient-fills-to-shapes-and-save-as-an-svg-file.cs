// HOW-TO: Create SVG with Filled Rectangles Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output SVG file path
            string outputPath = "output.svg";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Define canvas size and DPI
            int width = 600;
            int height = 400;
            int dpi = 96;

            // Create an SVG graphics context
            var graphics = new SvgGraphics2D(width, height, dpi);

            // Draw and fill a rectangle with a solid brush (gradient not supported in FillRectangle)
            var rectPen = new Pen(Color.Black, 2);
            var rectBrush = new SolidBrush(Color.LightBlue);
            graphics.DrawRectangle(rectPen, 50, 50, 200, 150);
            graphics.FillRectangle(rectPen, rectBrush, 50, 50, 200, 150);

            // Draw and fill another rectangle with a different solid color
            var rectPen2 = new Pen(Color.DarkGreen, 2);
            var rectBrush2 = new SolidBrush(Color.LightGreen);
            graphics.DrawRectangle(rectPen2, 300, 200, 250, 150);
            graphics.FillRectangle(rectPen2, rectBrush2, 300, 200, 250, 150);

            // Finalize the SVG image and save it
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
 * 1. Generate a scalable SVG diagram with colored rectangles for a web dashboard using C# and Aspose.Imaging.
 * 2. Programmatically create vector SVG assets with solid fills for responsive UI components without manual design.
 * 3. Export server‑side graphics as DPI‑aware SVG files for high‑quality printing or preview generation.
 * 4. Build a reporting service that inserts vector shapes with solid colors into PDF or HTML reports via Aspose.Imaging.
 * 5. Automate the creation of SVG icons or placeholders with specific dimensions and solid fills for a design system.
 */
