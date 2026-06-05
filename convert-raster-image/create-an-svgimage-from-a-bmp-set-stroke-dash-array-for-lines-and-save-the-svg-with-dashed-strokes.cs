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
        try
        {
            // Hardcoded input and output paths
            string inputBmpPath = "C:\\temp\\sample.bmp";
            string outputSvgPath = "C:\\temp\\output.svg";

            // Verify input file exists
            if (!File.Exists(inputBmpPath))
            {
                Console.Error.WriteLine($"File not found: {inputBmpPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));

            // Load the BMP image as a raster image
            using (RasterImage bmpImage = (RasterImage)Image.Load(inputBmpPath))
            {
                // Create an SVG graphics canvas with the same dimensions as the BMP
                var graphics = new SvgGraphics2D(bmpImage.Width, bmpImage.Height, 96);

                // Create a pen with a dash pattern (5 units dash, 5 units gap)
                var dashPen = new Pen(Color.Black, 2);
                dashPen.DashPattern = new float[] { 5, 5 };

                // Draw dashed diagonal lines on the SVG
                graphics.DrawLine(dashPen, 0, 0, bmpImage.Width, bmpImage.Height);
                graphics.DrawLine(dashPen, 0, bmpImage.Height, bmpImage.Width, 0);

                // Draw the bitmap onto the SVG canvas
                graphics.DrawImage(bmpImage, new Point(0, 0), new Size(bmpImage.Width, bmpImage.Height));

                // Finalize the SVG image and save it
                using (SvgImage svgImage = graphics.EndRecording())
                {
                    svgImage.Save(outputSvgPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}