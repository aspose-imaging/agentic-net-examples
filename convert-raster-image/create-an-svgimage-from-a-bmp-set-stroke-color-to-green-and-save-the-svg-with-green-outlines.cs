using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image as a raster image
        using (RasterImage bmpImage = (RasterImage)Image.Load(inputPath))
        {
            int width = bmpImage.Width;
            int height = bmpImage.Height;
            int dpi = 96; // Standard DPI

            // Create an SVG graphics canvas with the same dimensions as the BMP
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Draw the BMP onto the SVG canvas
            graphics.DrawImage(bmpImage, new Point(0, 0), new Size(width, height));

            // Draw a green rectangle outline around the image
            Pen greenPen = new Pen(Color.Green, 1);
            graphics.DrawRectangle(greenPen, 0, 0, width, height);

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}