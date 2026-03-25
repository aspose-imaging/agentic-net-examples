using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPngPath = "input.png";
        string outputSvgPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPngPath))
        {
            Console.Error.WriteLine($"File not found: {inputPngPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));

        // Load the PNG image to obtain its dimensions
        using (PngImage pngImage = new PngImage(inputPngPath))
        {
            int width = pngImage.Width;
            int height = pngImage.Height;
            int dpi = 96; // Standard screen DPI

            // Create an SVG graphics context with the same size as the PNG
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Define a linear gradient brush (top-left to bottom-right)
            // Gradient from Red to Blue
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new PointF(0, 0),               // start point
                new PointF(width, height),      // end point
                Color.Red,                      // start color
                Color.Blue);                    // end color

            // No outline pen (transparent)
            Pen transparentPen = new Pen(Color.Transparent, 0);

            // Fill the entire SVG canvas with the gradient
            graphics.FillRectangle(transparentPen, gradientBrush, 0, 0, width, height);

            // Optionally, draw the original PNG onto the SVG (as an image element)
            // This demonstrates embedding the raster image inside the SVG.
            graphics.DrawImage(pngImage, new Point(0, 0), new Size(width, height));

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputSvgPath);
            }
        }
    }
}