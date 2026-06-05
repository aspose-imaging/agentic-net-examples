using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image rasterImage = Image.Load(inputPath))
            {
                // Create an SVG graphics context with the same dimensions as the raster image
                var graphics = new SvgGraphics2D(rasterImage.Width, rasterImage.Height, 96);

                // Set stroke width to 3 pixels (black color)
                var pen = new Pen(Color.Black, 3);

                // Draw a rectangle border around the image area
                graphics.DrawRectangle(pen, 0, 0, rasterImage.Width, rasterImage.Height);

                // Finalize SVG recording and obtain the SvgImage
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