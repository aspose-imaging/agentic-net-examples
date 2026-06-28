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
            // Hardcoded output path
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
            Pen nodePen = new Pen(Color.Black, 2);
            Brush nodeBrush = new SolidBrush(Color.LightBlue);
            Pen connectorPen = new Pen(Color.DarkGray, 1);

            // Draw two rectangular nodes
            int nodeWidth = 120;
            int nodeHeight = 60;

            // Node 1 at (100,200)
            int node1X = 100;
            int node1Y = 200;
            graphics.DrawRectangle(nodePen, node1X, node1Y, nodeWidth, nodeHeight);
            graphics.FillRectangle(nodePen, nodeBrush, node1X, node1Y, nodeWidth, nodeHeight);

            // Node 2 at (500,200)
            int node2X = 500;
            int node2Y = 200;
            graphics.DrawRectangle(nodePen, node2X, node2Y, nodeWidth, nodeHeight);
            graphics.FillRectangle(nodePen, nodeBrush, node2X, node2Y, nodeWidth, nodeHeight);

            // Draw a connector line between the centers of the two nodes
            int node1CenterX = node1X + nodeWidth / 2;
            int node1CenterY = node1Y + nodeHeight / 2;
            int node2CenterX = node2X + nodeWidth / 2;
            int node2CenterY = node2Y + nodeHeight / 2;
            graphics.DrawLine(connectorPen, node1CenterX, node1CenterY, node2CenterX, node2CenterY);

            // Optionally add an arrowhead using a small triangle path
            GraphicsPath arrowPath = new GraphicsPath();
            Figure arrowFigure = new Figure { IsClosed = true };
            arrowPath.AddFigure(arrowFigure);
            // Simple arrowhead shape (triangle)
            arrowFigure.AddShapes(new Shape[]
            {
                new PolygonShape(new PointF[]
                {
                    new PointF(node2CenterX - 5, node2CenterY - 5),
                    new PointF(node2CenterX + 5, node2CenterY - 5),
                    new PointF(node2CenterX, node2CenterY + 5)
                })
            });
            graphics.FillPath(new Pen(Color.DarkGray, 1), new SolidBrush(Color.DarkGray), arrowPath);

            // Finalize SVG image
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
 * 1. When a developer needs to generate a scalable flowchart or network diagram on the fly in a C# web application and embed it as an SVG image in HTML pages.
 * 2. When an enterprise reporting tool must programmatically create vector‑based organizational charts with connector lines and export them as SVG files for high‑resolution printing or PDF conversion.
 * 3. When a SaaS platform wants to render interactive topology maps of server clusters using Aspose.Imaging for .NET, drawing nodes and links and saving the result as an SVG for responsive web display.
 * 4. When a documentation generator requires automatic creation of step‑by‑step process diagrams in C# and needs the output in a lightweight, searchable SVG format that scales on any device.
 * 5. When a data visualization dashboard needs to draw custom relationship graphs with rectangular nodes and connector lines at runtime and store them as SVG files for later reuse or client‑side manipulation.
 */