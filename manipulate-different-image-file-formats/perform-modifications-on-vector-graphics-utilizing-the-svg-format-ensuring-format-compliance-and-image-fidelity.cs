using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Prepare output directory
        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        int imageWidth = 600;
        int imageHeight = 400;
        int dpi = 96;

        // Create an SVG graphics canvas
        SvgGraphics2D graphics = new SvgGraphics2D(imageWidth, imageHeight, dpi);

        // Draw a black rectangle border
        graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1), 0, 0, imageWidth, imageHeight);

        // Fill inner rectangle with white‑smoke color
        using (SolidBrush fillBrush = new SolidBrush(Aspose.Imaging.Color.WhiteSmoke))
        {
            graphics.FillRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.WhiteSmoke, 1), fillBrush, 10, 10, imageWidth - 20, imageHeight - 20);
        }

        // Draw two diagonal lines
        graphics.DrawLine(new Aspose.Imaging.Pen(Aspose.Imaging.Color.DarkGreen, 1), 0, 0, imageWidth, imageHeight);
        graphics.DrawLine(new Aspose.Imaging.Pen(Aspose.Imaging.Color.DarkGreen, 1), 0, imageHeight, imageWidth, 0);

        // Draw an arc
        graphics.DrawArc(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2), new Aspose.Imaging.Rectangle(0, 0, 200, 200), 90, 270);

        // Fill an arc
        using (SolidBrush arcBrush = new SolidBrush(Aspose.Imaging.Color.LightSkyBlue))
        {
            graphics.FillArc(new Aspose.Imaging.Pen(Aspose.Imaging.Color.LightCoral, 10), arcBrush, new Aspose.Imaging.Rectangle(0, 0, 150, 150), 90, 270);
        }

        // Draw a cubic Bezier curve
        graphics.DrawCubicBezier(
            new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2),
            new Aspose.Imaging.PointF(0, 0),
            new Aspose.Imaging.PointF(200, 133),
            new Aspose.Imaging.PointF(400, 166),
            new Aspose.Imaging.PointF(600, 400));

        // Draw a text string
        graphics.DrawString(
            new Aspose.Imaging.Font("Arial", 48, Aspose.Imaging.FontStyle.Regular),
            "Hello World!",
            new Aspose.Imaging.Point(200, 300),
            Aspose.Imaging.Color.DarkRed);

        // Create a complex path to fill
        Aspose.Imaging.Figure figureToFill = new Aspose.Imaging.Figure { IsClosed = true };
        Aspose.Imaging.GraphicsPath pathToFill = new Aspose.Imaging.GraphicsPath();
        pathToFill.AddFigure(figureToFill);
        figureToFill.AddShapes(new Aspose.Imaging.Shape[]
        {
            new Aspose.Imaging.Shapes.ArcShape(new Aspose.Imaging.Rectangle(400, 0, 200, 100), 45, 300),
            new Aspose.Imaging.Shapes.BezierShape(new Aspose.Imaging.PointF[]
            {
                new Aspose.Imaging.PointF(300, 200),
                new Aspose.Imaging.PointF(400, 200),
                new Aspose.Imaging.PointF(500, 100),
                new Aspose.Imaging.PointF(600, 200)
            }),
            new Aspose.Imaging.Shapes.PolygonShape(new Aspose.Imaging.PointF[]
            {
                new Aspose.Imaging.PointF(300, 100)
            }),
            new Aspose.Imaging.Shapes.RectangleShape(new Aspose.Imaging.RectangleF(0, 100, 200, 200))
        });

        using (SolidBrush fillPathBrush = new SolidBrush(Aspose.Imaging.Color.Yellow))
        {
            graphics.FillPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 2), fillPathBrush, pathToFill);
        }

        // Create a simple path to draw
        Aspose.Imaging.Figure figureToDraw = new Aspose.Imaging.Figure();
        Aspose.Imaging.GraphicsPath pathToDraw = new Aspose.Imaging.GraphicsPath();
        pathToDraw.AddFigure(figureToDraw);
        figureToDraw.AddShapes(new Aspose.Imaging.Shape[]
        {
            new Aspose.Imaging.Shapes.ArcShape(new Aspose.Imaging.RectangleF(200, 200, 200, 200), 0, 360)
        });

        graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Orange, 5), pathToDraw);

        // Finalize and save the SVG image
        using (SvgImage svgImage = graphics.EndRecording())
        {
            string outputPath = Path.Combine(outputDir, "result.svg");
            svgImage.Save(outputPath);
        }
    }
}