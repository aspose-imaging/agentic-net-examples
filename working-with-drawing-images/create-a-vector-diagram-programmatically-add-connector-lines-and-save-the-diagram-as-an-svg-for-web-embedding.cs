using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path for the SVG file
            string outputPath = @"C:\temp\diagram.svg";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image size and DPI
            int width = 800;
            int height = 600;
            int dpi = 96;

            // Create an SVG graphics context
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Define pens and brushes
            Pen rectPen = new Pen(Color.Black, 2);
            Pen connectorPen = new Pen(Color.DarkBlue, 1);
            SolidBrush rectBrush = new SolidBrush(Color.LightGray);

            // Draw first rectangle
            int rect1X = 100, rect1Y = 100, rect1W = 200, rect1H = 150;
            graphics.FillRectangle(rectPen, rectBrush, rect1X, rect1Y, rect1W, rect1H);
            graphics.DrawRectangle(rectPen, rect1X, rect1Y, rect1W, rect1H);

            // Draw second rectangle
            int rect2X = 500, rect2Y = 300, rect2W = 200, rect2H = 150;
            graphics.FillRectangle(rectPen, rectBrush, rect2X, rect2Y, rect2W, rect2H);
            graphics.DrawRectangle(rectPen, rect2X, rect2Y, rect2W, rect2H);

            // Calculate center points of the rectangles
            int rect1CenterX = rect1X + rect1W / 2;
            int rect1CenterY = rect1Y + rect1H / 2;
            int rect2CenterX = rect2X + rect2W / 2;
            int rect2CenterY = rect2Y + rect2H / 2;

            // Draw connector line between the two rectangles
            graphics.DrawLine(connectorPen, rect1CenterX, rect1CenterY, rect2CenterX, rect2CenterY);

            // Optionally, add a label inside each rectangle
            Font labelFont = new Font("Arial", 24, FontStyle.Regular);
            graphics.DrawString(labelFont, "Box 1", new Point(rect1X + 20, rect1Y + rect1H / 2), Color.Black);
            graphics.DrawString(labelFont, "Box 2", new Point(rect2X + 20, rect2Y + rect2H / 2), Color.Black);

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
 * 1. When a developer needs to generate a scalable vector diagram of system components on the fly and embed it as an SVG in a web page, they can use this Aspose.Imaging for .NET code to draw rectangles and connector lines programmatically.
 * 2. When building a reporting tool that visualizes workflow steps as boxes linked by arrows, the code creates the SVG graphics with precise DPI and dimensions without manual design.
 * 3. When an application must export architectural diagrams to a portable file format for client‑side rendering, this C# snippet produces an SVG file that scales cleanly across browsers.
 * 4. When automating the creation of network topology maps where each node is represented by a rectangle and connections are drawn as lines, the Aspose.Imaging API handles the drawing and saving process.
 * 5. When integrating dynamic diagram generation into a SaaS dashboard that requires on‑demand SVG images for printable documentation, the example shows how to programmatically draw shapes, apply pens and brushes, and save the result.
 */