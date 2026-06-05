using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\sample_green.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image as a raster image
            using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
            {
                int width = bmp.Width;
                int height = bmp.Height;
                int dpi = 96;

                // Create an SVG graphics canvas with the same dimensions as the BMP
                var graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(bmp, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

                // Draw a green outline around the image
                var greenPen = new Pen(Color.Green, 1);
                graphics.DrawRectangle(greenPen, 0, 0, width, height);

                // Finalize the SVG image
                using (SvgImage svg = graphics.EndRecording())
                {
                    // Save the SVG with green outlines
                    svg.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}