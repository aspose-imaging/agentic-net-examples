using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output SVG file paths
        string inputPath = args.Length > 0 ? args[0] : "input.svg";
        string outputPath = args.Length > 1 ? args[1] : "output.svg";

        // Load the existing SVG image
        using (Image image = Image.Load(inputPath))
        {
            SvgImage svgImage = (SvgImage)image;

            // Initialize graphics object for the loaded SVG
            SvgGraphics2D graphics = new SvgGraphics2D(svgImage);

            // Draw a black rectangle along the borders
            graphics.DrawRectangle(new Pen(Color.Black, 2), 0, 0, svgImage.Width, svgImage.Height);

            // Fill a semi‑transparent rectangle
            using (SolidBrush fillBrush = new SolidBrush(Color.FromArgb(128, Color.LightBlue)))
            {
                graphics.FillRectangle(new Pen(Color.DarkBlue, 1), fillBrush, 20, 20, svgImage.Width - 40, svgImage.Height - 40);
            }

            // Draw a diagonal line
            graphics.DrawLine(new Pen(Color.Red, 3), 0, 0, svgImage.Width, svgImage.Height);

            // Add some text
            Font textFont = new Font("Arial", 24, FontStyle.Bold);
            graphics.DrawString(textFont, "Edited SVG", new Point(50, 50), Color.DarkGreen);

            // Create a simple path (triangle) and fill it
            Figure triangleFigure = new Figure { IsClosed = true };
            triangleFigure.AddShapes(new Shape[]
            {
                new PolygonShape(new PointF[]
                {
                    new PointF(svgImage.Width / 2, 100),
                    new PointF(svgImage.Width - 100, svgImage.Height - 100),
                    new PointF(100, svgImage.Height - 100)
                })
            });

            GraphicsPath trianglePath = new GraphicsPath();
            trianglePath.AddFigure(triangleFigure);

            using (SolidBrush triangleBrush = new SolidBrush(Color.Yellow))
            {
                graphics.FillPath(new Pen(Color.Orange, 2), triangleBrush, trianglePath);
            }

            // Finalize and save the edited SVG
            using (SvgImage resultImage = graphics.EndRecording())
            {
                resultImage.Save(outputPath);
            }
        }
    }
}