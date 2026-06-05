using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input raster image and output SVG paths
            string inputPath = "input.png";
            string outputPath = "output.svg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (creates current directory if none)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for drawing operations
                RasterImage raster = (RasterImage)image;

                // Define custom SVG viewbox dimensions
                int svgWidth = 800;   // width in pixels
                int svgHeight = 600;  // height in pixels
                int dpi = 96;         // resolution

                // Create an SVG graphics canvas with the specified size
                SvgGraphics2D graphics = new SvgGraphics2D(svgWidth, svgHeight, dpi);

                // Draw the raster image onto the SVG canvas, scaling to fit the viewbox
                graphics.DrawImage(raster, new Point(0, 0), new Size(svgWidth, svgHeight));

                // Finalize the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
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