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

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the BMP raster image
        using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
        {
            // Create an SVG graphics context with the same dimensions as the BMP
            int width = rasterImage.Width;
            int height = rasterImage.Height;
            int dpi = 96; // standard DPI

            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(rasterImage, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

            // Create a pen with dashed stroke
            Pen dashedPen = new Pen(Color.Black, 2);
            dashedPen.DashPattern = new float[] { 5, 5 }; // 5 units dash, 5 units gap

            // Draw a diagonal dashed line across the image
            graphics.DrawLine(dashedPen, 0, 0, width, height);

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
}