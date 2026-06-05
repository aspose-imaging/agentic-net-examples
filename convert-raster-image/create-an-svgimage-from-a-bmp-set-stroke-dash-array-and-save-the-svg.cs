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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
            {
                int width = bmp.Width;
                int height = bmp.Height;
                int dpi = 96;

                // Create an SVG graphics canvas with the same dimensions as the BMP
                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                // Create a pen with a dash pattern
                Pen dashPen = new Pen(Color.Black, 2);
                dashPen.DashPattern = new float[] { 5, 3 }; // 5 units dash, 3 units gap

                // Draw a dashed rectangle border around the image area
                graphics.DrawRectangle(dashPen, 0, 0, width, height);

                // Draw the BMP onto the SVG canvas
                graphics.DrawImage(bmp, new Point(0, 0), new Size(width, height));

                // Finalize the SVG image and save it
                using (SvgImage svgImage = graphics.EndRecording())
                {
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