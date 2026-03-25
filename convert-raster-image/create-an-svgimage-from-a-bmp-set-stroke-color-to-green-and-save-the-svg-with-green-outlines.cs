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
        string inputBmpPath = "input.bmp";
        string outputSvgPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputBmpPath))
        {
            Console.Error.WriteLine($"File not found: {inputBmpPath}");
            return;
        }

        // Load the BMP image
        using (RasterImage bmp = (RasterImage)Image.Load(inputBmpPath))
        {
            int width = bmp.Width;
            int height = bmp.Height;
            int dpi = 96; // Standard DPI

            // Create an SVG graphics context with the same dimensions as the BMP
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(bmp, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(width, height));

            // Draw a green outline around the image
            graphics.DrawRectangle(new Pen(Color.Green, 1), 0, 0, width, height);

            // Finalize the SVG image
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));

                // Save the SVG file
                svgImage.Save(outputSvgPath);
            }
        }
    }
}