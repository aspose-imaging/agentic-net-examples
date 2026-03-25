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
        // Hardcoded input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
        {
            // Create an SVG graphics context with the same dimensions as the BMP
            int dpi = 96;
            SvgGraphics2D graphics = new SvgGraphics2D(bmp.Width, bmp.Height, dpi);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(bmp, new Point(0, 0), new Size(bmp.Width, bmp.Height));

            // Set stroke width for vector paths (e.g., a rectangle border around the image)
            Pen borderPen = new Pen(Color.Black, 5); // 5-pixel-wide stroke
            graphics.DrawRectangle(borderPen, 0, 0, bmp.Width, bmp.Height);

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the customized SVG
                svgImage.Save(outputPath);
            }
        }
    }
}