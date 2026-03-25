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
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the PNG raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            int width = raster.Width;
            int height = raster.Height;
            int dpi = 96; // Standard screen DPI

            // Create an SVG graphics context with the same dimensions
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

            // Draw a red stroke rectangle (outline) around the image
            Aspose.Imaging.Pen redPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 1);
            graphics.DrawRectangle(redPen, 0, 0, width, height);

            // Finalize the SVG image and save it
            using (SvgImage svgImage = graphics.EndRecording())
            {
                svgImage.Save(outputPath);
            }
        }
    }
}