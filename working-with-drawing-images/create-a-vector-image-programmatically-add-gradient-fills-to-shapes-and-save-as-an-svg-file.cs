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
        // Output SVG file path
        string outputPath = "output.svg";

        // Ensure the output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Canvas size and DPI
        int width = 600;
        int height = 400;
        int dpi = 96;

        // Create an SVG graphics context
        var graphics = new SvgGraphics2D(width, height, dpi);

        // Gradient fills are not supported by Graphics.FillXXX methods.
        // Fallback to a solid brush with a color that approximates the desired gradient.
        var rectPen = new Pen(Color.Black, 2);
        var rectBrush = new SolidBrush(Color.LightBlue);
        graphics.FillRectangle(rectPen, rectBrush, 50, 50, 200, 150);

        // Draw another rectangle with a different solid fill as a placeholder for a gradient.
        var rectPen2 = new Pen(Color.DarkGreen, 2);
        var rectBrush2 = new SolidBrush(Color.Pink);
        graphics.FillRectangle(rectPen2, rectBrush2, 300, 200, 250, 150);

        // Finalize and save the SVG image
        using (SvgImage svgImage = graphics.EndRecording())
        {
            svgImage.Save(outputPath);
        }
    }
}