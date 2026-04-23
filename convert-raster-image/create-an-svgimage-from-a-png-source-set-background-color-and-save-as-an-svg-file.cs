using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image pngImage = Image.Load(inputPath))
        {
            // Cast to RasterImage to access pixel data
            RasterImage raster = (RasterImage)pngImage;
            int width = raster.Width;
            int height = raster.Height;
            int dpi = 96; // Standard screen DPI

            // Create an SVG graphics canvas
            var graphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(width, height, dpi);

            // Set background color by filling the entire canvas
            Pen backgroundPen = new Pen(Color.White, 1);
            SolidBrush backgroundBrush = new SolidBrush(Color.White);
            graphics.FillRectangle(backgroundPen, backgroundBrush, 0, 0, width, height);

            // Draw the PNG raster image onto the SVG canvas
            graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file
                svgImage.Save(outputPath);
            }
        }
    }
}