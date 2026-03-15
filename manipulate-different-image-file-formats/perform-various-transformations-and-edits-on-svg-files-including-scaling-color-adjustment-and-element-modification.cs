using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : Path.Combine("C:", "temp", "input.svg");
        string outputPath = args.Length > 1 ? args[1] : Path.Combine("C:", "temp", "output.svg");

        using (Image image = Image.Load(inputPath))
        {
            SvgImage svgImage = (SvgImage)image;

            // Scale the SVG to new dimensions.
            svgImage.Resize(400, 300, ResizeType.LanczosResample);

            // Set a light gray background.
            svgImage.BackgroundColor = Color.LightGray;
            svgImage.HasBackgroundColor = true;

            // Draw a red rectangle and fill it with yellow.
            var graphics = new SvgGraphics2D(svgImage);
            var pen = new Pen(Color.Red, 3);
            var brush = new SolidBrush(Color.Yellow);
            graphics.DrawRectangle(pen, 20, 20, 360, 260);
            graphics.FillRectangle(pen, brush, 20, 20, 360, 260);

            // Save the modified SVG.
            svgImage.Save(outputPath);
        }

        Console.WriteLine("SVG processing completed.");
    }
}