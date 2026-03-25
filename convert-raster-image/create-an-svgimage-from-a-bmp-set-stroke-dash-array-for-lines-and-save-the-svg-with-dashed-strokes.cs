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
        string inputPath = "sample.bmp";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP raster image
        using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
        {
            // Create an SVG graphics context with the same dimensions as the raster image
            int width = rasterImage.Width;
            int height = rasterImage.Height;
            int dpi = 96; // standard screen DPI

            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(rasterImage, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

            // Create a pen with a dash pattern for drawing lines
            Pen dashedPen = new Pen(Color.Black, 2);
            // Set a custom dash pattern: 5 units dash, 5 units gap
            dashedPen.DashPattern = new float[] { 5, 5 };

            // Example dashed line (optional, demonstrates the dash style)
            graphics.DrawLine(dashedPen, 0, 0, width, height);

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}