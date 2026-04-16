using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.png";
        string outputPath = "result.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image as a raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            int width = raster.Width;
            int height = raster.Height;
            int dpi = 96;

            // Create SVG graphics canvas
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Create a linear gradient brush from top‑left (red) to bottom‑right (blue)
            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(width, height),
                Color.Red,
                Color.Blue))
            {
                // Pen with zero width (no outline)
                Pen pen = new Pen(Color.Black, 0);

                // Fill the entire canvas with the gradient
                graphics.FillRectangle(pen, gradientBrush, 0, 0, width, height);
            }

            // Obtain the final SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}