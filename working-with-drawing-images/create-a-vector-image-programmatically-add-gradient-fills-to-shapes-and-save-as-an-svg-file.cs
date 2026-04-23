using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Define output path
        string outputPath = @"C:\Temp\vector_output.svg";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Canvas size
        int width = 600;
        int height = 400;
        int dpi = 96;

        // Create SVG graphics context
        SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

        // Draw outer border
        Pen borderPen = new Pen(Color.Black, 2);
        graphics.DrawRectangle(borderPen, 0, 0, width, height);

        // Fill a rectangle (solid brush)
        Pen rectPen = new Pen(Color.Blue, 1);
        using (SolidBrush rectBrush = new SolidBrush(Color.LightBlue))
        {
            graphics.FillRectangle(rectPen, rectBrush, 50, 50, 200, 150);
        }

        // Create an ellipse shape and fill it
        Figure ellipseFigure = new Figure { IsClosed = true };
        GraphicsPath ellipsePath = new GraphicsPath();
        ellipsePath.AddFigure(ellipseFigure);
        ellipseFigure.AddShapes(new Shape[]
        {
            new EllipseShape(new Rectangle(300, 50, 150, 150))
        });

        Pen ellipsePen = new Pen(Color.Green, 2);
        using (SolidBrush ellipseBrush = new SolidBrush(Color.Yellow))
        {
            graphics.FillPath(ellipsePen, ellipseBrush, ellipsePath);
        }

        // Finalize SVG image and save
        using (SvgImage svgImage = graphics.EndRecording())
        {
            svgImage.Save(outputPath);
        }
    }
}