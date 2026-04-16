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
        string inputPath = "sample.bmp";
        string outputPath = "dashed_output.svg";

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
            Pen dashPen = new Pen(Color.Black, 2);
            dashPen.DashPattern = new float[] { 5, 5 }; // 5 units dash, 5 units gap

            // Draw a rectangle around the image using the dashed pen
            graphics.DrawRectangle(dashPen, 0, 0, width, height);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(raster, new Point(0, 0));

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}