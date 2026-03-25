using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the PNG image
        using (RasterImage pngImage = (RasterImage)Image.Load(inputPath))
        {
            int width = pngImage.Width;
            int height = pngImage.Height;
            int dpi = 96; // Standard DPI

            // Create SVG graphics canvas with same dimensions as PNG
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Draw the PNG onto the SVG canvas
            graphics.DrawImage(pngImage, new Point(0, 0), new Size(width, height));

            // Set stroke width to 2 pixels and draw a border rectangle
            Pen borderPen = new Pen(Color.Black, 2);
            graphics.DrawRectangle(borderPen, 0, 0, width, height);

            // Finalize SVG image and save
            using (SvgImage svgImage = graphics.EndRecording())
            {
                svgImage.Save(outputPath);
            }
        }
    }
}