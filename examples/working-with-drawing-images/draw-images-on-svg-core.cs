using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Define canvas size and DPI
        int imageWidth = 600;
        int imageHeight = 400;
        int dpi = 96;

        // Create an SVG graphics canvas
        SvgGraphics2D graphics = new SvgGraphics2D(imageWidth, imageHeight, dpi);

        // Draw a black border rectangle
        graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, imageWidth, imageHeight);

        // Fill the background with WhiteSmoke
        graphics.FillRectangle(new Pen(Color.WhiteSmoke, 1), new SolidBrush(Color.WhiteSmoke), 10, 10, 580, 380);

        // Draw two diagonal lines
        graphics.DrawLine(new Pen(Color.DarkGreen, 1), 0, 0, imageWidth, imageHeight);
        graphics.DrawLine(new Pen(Color.DarkGreen, 1), 0, imageHeight, imageWidth, 0);

        // Draw and fill an arc
        graphics.DrawArc(new Pen(Color.Blue, 2), new Rectangle(0, 0, 200, 200), 90, 270);
        graphics.FillArc(new Pen(Color.LightCoral, 10), new SolidBrush(Color.LightSkyBlue), new Rectangle(0, 0, 150, 150), 90, 270);

        // Draw a cubic Bezier curve
        graphics.DrawCubicBezier(
            new Pen(Color.Red, 2),
            new PointF(0, 0),
            new PointF(200, 133),
            new PointF(400, 166),
            new PointF(600, 400));

        // Draw an external raster image (replace with a valid path if needed)
        string rasterPath = "sample.bmp";
        using (RasterImage imageToDraw = (RasterImage)Image.Load(rasterPath))
        {
            graphics.DrawImage(imageToDraw, new Point(400, 200), new Size(100, 50));
        }

        // Draw a text string
        graphics.DrawString(
            new Font("Arial", 48, FontStyle.Regular),
            "Hello World!",
            new Point(200, 300),
            Color.DarkRed);

        // Create a complex path to fill
        Figure figureToFill = new Figure { IsClosed = true };
        GraphicsPath pathToFill = new GraphicsPath();
        pathToFill.AddFigure(figureToFill);
        figureToFill.AddShapes(new Shape[]
        {
            new ArcShape(new Rectangle(400, 0, 200, 100), 45, 300),
            new BezierShape(new PointF[]
            {
                new PointF(300, 200),
                new PointF(400, 200),
                new PointF(500, 100),
                new PointF(600, 200)
            }),
            new PolygonShape(new PointF[]
            {
                new PointF(300, 100)
            }),
            new RectangleShape(new RectangleF(0, 100, 200, 200))
        });
        graphics.FillPath(new Pen(Color.Green, 2), new SolidBrush(Color.Yellow), pathToFill);

        // Create a simple path to draw
        Figure figureToDraw = new Figure();
        GraphicsPath pathToDraw = new GraphicsPath();
        pathToDraw.AddFigure(figureToDraw);
        figureToDraw.AddShapes(new Shape[]
        {
            new ArcShape(new RectangleF(200, 200, 200, 200), 0, 360)
        });
        graphics.DrawPath(new Pen(Color.Orange, 5), pathToDraw);

        // Finalize and save the SVG image
        using (SvgImage svgImage = graphics.EndRecording())
        {
            svgImage.Save("output.svg");
        }
    }
}