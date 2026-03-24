using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input raster image path
        string rasterPath = "C:\\temp\\sample.bmp";
        // Hardcoded output SVG path
        string svgOutputPath = "C:\\temp\\output.svg";

        // Verify input file exists
        if (!File.Exists(rasterPath))
        {
            Console.Error.WriteLine($"File not found: {rasterPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

        // Define SVG canvas dimensions and DPI
        int canvasWidth = 800;
        int canvasHeight = 600;
        int dpi = 96;

        // Create an SVG graphics context
        var graphics = new SvgGraphics2D(canvasWidth, canvasHeight, dpi);

        // Load the raster image and draw it onto the SVG canvas
        using (RasterImage rasterImage = (RasterImage)Image.Load(rasterPath))
        {
            // Position where the image will be placed on the canvas
            var position = new Point(100, 150);
            // Desired size of the drawn image (scales the source)
            var size = new Size(300, 200);
            graphics.DrawImage(rasterImage, position, size);
        }

        // Finalize the SVG image and save it to the output path
        using (SvgImage svgImage = graphics.EndRecording())
        {
            svgImage.Save(svgOutputPath);
        }
    }
}