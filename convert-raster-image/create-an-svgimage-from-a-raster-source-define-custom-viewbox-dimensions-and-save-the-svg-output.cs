using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\result.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load raster image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to RasterImage
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // Define custom SVG canvas size and DPI
            int canvasWidth = 800;
            int canvasHeight = 600;
            int dpi = 96;

            // Create SVG graphics canvas
            SvgGraphics2D graphics = new SvgGraphics2D(canvasWidth, canvasHeight, dpi);

            // Draw the raster image onto the SVG canvas, scaling to fit the canvas
            graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(canvasWidth, canvasHeight));

            // Finalize SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}