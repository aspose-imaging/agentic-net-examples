using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output SVG file path
            string outputPath = "output.svg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Canvas size and DPI
            int width = 400;
            int height = 300;
            int dpi = 96;

            // Create SVG graphics context
            var graphics = new SvgGraphics2D(width, height, dpi);

            // Gradient brush for rectangle fill (red to blue)
            var rectGradient = new LinearGradientBrush(new Point(0, 0), new Point(width, 0), Color.Red, Color.Blue);
            var rectPen = new Pen(Color.Black, 2);
            graphics.FillRectangle(rectPen, rectGradient, 50, 50, 300, 200);

            // Create a circular shape
            var circleFigure = new Figure { IsClosed = true };
            var circlePath = new GraphicsPath();
            circlePath.AddFigure(circleFigure);
            var ellipse = new EllipseShape(new Rectangle(100, 80, 200, 200));
            circleFigure.AddShape(ellipse);

            // Gradient brush for circle fill (green to yellow)
            var circleGradient = new LinearGradientBrush(new Point(100, 80), new Point(300, 280), Color.Green, Color.Yellow);
            graphics.FillPath(rectPen, circleGradient, circlePath);

            // Finalize and save SVG image
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