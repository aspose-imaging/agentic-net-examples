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
        // Hardcoded input and output paths
        string outputPath = @"C:\Temp\VectorDiagram.svg";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image size and resolution
            int imageWidth = 800;
            int imageHeight = 600;
            int dpi = 96;

            // Create an SVG graphics context
            SvgGraphics2D graphics = new SvgGraphics2D(imageWidth, imageHeight, dpi);

            // Define pens and brushes
            Pen rectPen = new Pen(Color.Blue, 2);
            Pen linePen = new Pen(Color.Red, 1);
            Brush fillBrush = new SolidBrush(Color.LightGray);

            // Draw first rectangle
            int rect1X = 50;
            int rect1Y = 50;
            int rect1Width = 150;
            int rect1Height = 100;
            graphics.DrawRectangle(rectPen, rect1X, rect1Y, rect1Width, rect1Height);
            graphics.FillRectangle(rectPen, fillBrush, rect1X, rect1Y, rect1Width, rect1Height);

            // Draw second rectangle
            int rect2X = 400;
            int rect2Y = 300;
            int rect2Width = 200;
            int rect2Height = 150;
            graphics.DrawRectangle(rectPen, rect2X, rect2Y, rect2Width, rect2Height);
            graphics.FillRectangle(rectPen, fillBrush, rect2X, rect2Y, rect2Width, rect2Height);

            // Calculate centers of the rectangles
            int rect1CenterX = rect1X + rect1Width / 2;
            int rect1CenterY = rect1Y + rect1Height / 2;
            int rect2CenterX = rect2X + rect2Width / 2;
            int rect2CenterY = rect2Y + rect2Height / 2;

            // Draw a connector line between the two rectangles
            graphics.DrawLine(linePen, rect1CenterX, rect1CenterY, rect2CenterX, rect2CenterY);

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}