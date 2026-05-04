using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\result.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to RasterImage for drawing
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Create an SVG canvas with custom viewbox dimensions (width=500, height=300, dpi=96)
                SvgGraphics2D graphics = new SvgGraphics2D(500, 300, 96);

                // Draw the raster image onto the SVG canvas, scaling to fit the canvas size
                graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(500, 300));

                // Finalize the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save the SVG output
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