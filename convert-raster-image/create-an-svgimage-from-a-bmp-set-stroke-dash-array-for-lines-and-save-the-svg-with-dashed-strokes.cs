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
            string outputPath = "C:\\temp\\output.svg";

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
                int width = bmp.Width;
                int height = bmp.Height;
                int dpi = 96;

                // Create an SVG graphics context with the same dimensions as the BMP
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Draw the bitmap onto the SVG canvas
                graphics.DrawImage(bmp, new Point(0, 0));

                // Create a pen with a dashed stroke pattern
                Pen dashedPen = new Pen(Color.Black, 2);
                // 5 units on, 5 units off
                dashedPen.DashPattern = new float[] { 5, 5 };

                // Draw a diagonal line using the dashed pen
                graphics.DrawLine(dashedPen, 0, 0, width, height);

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