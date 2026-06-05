using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
            {
                // Define custom SVG canvas size and DPI
                int svgWidth = 500;   // custom width
                int svgHeight = 500;  // custom height
                int dpi = 96;         // standard screen DPI

                // Create an SVG graphics recorder
                var graphics = new SvgGraphics2D(svgWidth, svgHeight, dpi);

                // Draw the BMP onto the SVG canvas, scaling to fit the custom size
                graphics.DrawImage(bmp, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(svgWidth, svgHeight));

                // Finish recording and obtain the SvgImage instance
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Set a custom viewbox if needed.
                    // Aspose.Imaging does not expose a direct ViewBox property,
                    // but the viewbox defaults to "0 0 width height" which matches our canvas.
                    // For more complex scenarios, manipulate the underlying XML.

                    // Save the SVG file
                    svgImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}