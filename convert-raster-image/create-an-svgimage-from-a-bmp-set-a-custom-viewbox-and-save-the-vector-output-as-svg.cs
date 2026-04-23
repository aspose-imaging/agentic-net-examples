using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.bmp");
        string outputPath = Path.Combine("Output", "output.svg");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image bmpImage = Image.Load(inputPath))
        {
            // Create an SVG canvas with custom size (viewbox)
            int svgWidth = 500;   // custom width
            int svgHeight = 500;  // custom height
            int dpi = 96;

            SvgGraphics2D graphics = new SvgGraphics2D(svgWidth, svgHeight, dpi);

            // Draw the BMP onto the SVG canvas
            graphics.DrawImage((RasterImage)bmpImage, new Point(0, 0), new Size(svgWidth, svgHeight));

            // Finalize SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}