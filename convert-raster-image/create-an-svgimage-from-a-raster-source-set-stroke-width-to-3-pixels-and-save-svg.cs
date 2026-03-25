using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.png";
        string outputPath = "output\\result.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            int width = raster.Width;
            int height = raster.Height;
            int dpi = 96; // Standard DPI

            // Create SVG graphics canvas
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Set stroke width to 3 pixels using a pen
            Pen pen = new Pen(Color.Black, 3);

            // Draw a rectangle border with the specified pen
            graphics.DrawRectangle(pen, 0, 0, width, height);

            // Optionally embed the raster image into the SVG
            graphics.DrawImage(raster, new Point(0, 0));

            // Finalize SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save SVG to the output path
                svgImage.Save(outputPath);
            }
        }
    }
}