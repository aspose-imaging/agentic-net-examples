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
        // Hardcoded output path
        string outputPath = "C:\\temp\\diagram.svg";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create an SVG graphics context
        int width = 800;
        int height = 600;
        int dpi = 96;
        SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

        // Draw two rectangles that will be connected
        Pen blackPen = new Pen(Color.Black, 2);
        graphics.DrawRectangle(blackPen, 100, 100, 200, 150);   // First rectangle
        graphics.DrawRectangle(blackPen, 400, 300, 250, 180);   // Second rectangle

        // Draw a connector line between the centers of the rectangles
        Pen connectorPen = new Pen(Color.Red, 1);
        int x1 = 100 + 200 / 2;
        int y1 = 100 + 150 / 2;
        int x2 = 400 + 250 / 2;
        int y2 = 300 + 180 / 2;
        graphics.DrawLine(connectorPen, x1, y1, x2, y2);

        // Add a simple arrowhead at the end of the connector line
        GraphicsPath arrowPath = new GraphicsPath();
        Figure arrowFigure = new Figure { IsClosed = true };
        arrowPath.AddFigure(arrowFigure);

        float arrowSize = 10f;
        float dx = x2 - x1;
        float dy = y2 - y1;
        float length = (float)Math.Sqrt(dx * dx + dy * dy);
        float ux = dx / length;
        float uy = dy / length;

        // Base point (end of line)
        float bx = x2;
        float by = y2;

        // Two other points forming a triangle
        float px1 = bx - ux * arrowSize - uy * arrowSize / 2;
        float py1 = by - uy * arrowSize + ux * arrowSize / 2;
        float px2 = bx - ux * arrowSize + uy * arrowSize / 2;
        float py2 = by - uy * arrowSize - ux * arrowSize / 2;

        arrowFigure.AddShapes(new Shape[]
        {
            new PolygonShape(new PointF[]
            {
                new PointF(bx, by),
                new PointF(px1, py1),
                new PointF(px2, py2)
            })
        });

        // Fill the arrowhead
        graphics.FillPath(new Pen(Color.Red, 1), new SolidBrush(Color.Red), arrowPath);

        // Finalize the SVG image and save it
        using (SvgImage svgImage = graphics.EndRecording())
        {
            svgImage.Save(outputPath);
        }
    }
}