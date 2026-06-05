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
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Create an SVG graphics context with the same dimensions as the raster image
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96;
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Create a pen with a dash pattern
                Pen dashedPen = new Pen(Color.Black, 2);
                dashedPen.DashPattern = new float[] { 5, 5 }; // 5 units dash, 5 units gap

                // Draw a diagonal line using the dashed pen
                graphics.DrawLine(dashedPen, 0, 0, width, height);

                // Obtain the final SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Ensure the output directory exists
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