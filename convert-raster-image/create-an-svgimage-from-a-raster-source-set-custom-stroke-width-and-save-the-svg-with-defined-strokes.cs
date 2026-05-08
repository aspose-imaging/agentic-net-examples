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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output/output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Create SVG graphics with same dimensions as raster
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96;
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Define a custom pen with desired stroke width
                Pen customPen = new Pen(Color.Black, 5);

                // Draw a rectangle border around the image using the custom pen
                graphics.DrawRectangle(customPen, 0, 0, width, height);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

                // Finalize SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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