using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input BMP file path
        string inputPath = @"C:\temp\sample.bmp";
        // Hardcoded output SVG file path
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP raster image
        using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
        {
            // Use BMP dimensions for the SVG canvas
            int canvasWidth = bmp.Width;
            int canvasHeight = bmp.Height;
            int dpi = 96; // Standard screen DPI

            // Create SVG graphics context (fully qualified because the namespace is not in the allowed using list)
            var svgGraphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(canvasWidth, canvasHeight, dpi);

            // Draw the BMP onto the SVG canvas, scaling to fit the canvas exactly
            svgGraphics.DrawImage(bmp, new Point(0, 0), new Size(canvasWidth, canvasHeight));

            // Finalize SVG image and save
            using (SvgImage svgImage = svgGraphics.EndRecording())
            {
                svgImage.Save(outputPath);
            }
        }
    }
}