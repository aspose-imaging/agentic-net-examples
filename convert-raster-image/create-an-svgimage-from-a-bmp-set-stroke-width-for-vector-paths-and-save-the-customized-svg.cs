using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\sample.bmp";
            string outputPath = "C:\\temp\\customized.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
            {
                int width = bmp.Width;
                int height = bmp.Height;
                int dpi = 96;

                // Create an SVG graphics context with the same dimensions
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the raster BMP onto the SVG canvas
                graphics.DrawImage(bmp, new Point(0, 0), new Size(width, height));

                // Set a custom stroke width for a vector path (e.g., a rectangle border)
                Pen thickPen = new Pen(Color.Black, 5); // 5-pixel stroke width
                graphics.DrawRectangle(thickPen, 0, 0, width, height);

                // Finalize the SVG image
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    // Save the customized SVG
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