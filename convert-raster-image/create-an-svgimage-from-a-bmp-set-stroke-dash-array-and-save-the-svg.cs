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
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP raster image
        using (RasterImage bmpImage = (RasterImage)Image.Load(inputPath))
        {
            // Create an SVG graphics context with the same dimensions as the BMP
            int width = bmpImage.Width;
            int height = bmpImage.Height;
            int dpi = 96; // standard screen DPI

            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Create a pen with a dash pattern (e.g., 5 units on, 3 units off)
            Pen dashPen = new Pen(Color.Black, 1);
            dashPen.DashPattern = new float[] { 5, 3 };

            // Draw the BMP onto the SVG using the dashed pen for the outline
            // First, draw a rectangle around the image using the dashed pen
            graphics.DrawRectangle(dashPen, 0, 0, width, height);

            // Then draw the bitmap itself
            graphics.DrawImage(bmpImage, new Point(0, 0), new Size(width, height));

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG to the output path
                svgImage.Save(outputPath);
            }
        }
    }
}