using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Path to the raster image to be drawn onto the SVG.
        string rasterPath = "sample.png";

        // Path where the resulting SVG will be saved.
        string outputSvgPath = "output.svg";

        // Load the raster image to obtain its dimensions.
        using (RasterImage raster = (RasterImage)Image.Load(rasterPath))
        {
            int width = raster.Width;
            int height = raster.Height;
            int dpi = 96; // Standard screen DPI.

            // Create an SVG canvas with the same size as the raster image.
            SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

            // Draw the raster image at the top‑left corner of the SVG canvas.
            graphics.DrawImage(raster, new Point(0, 0));

            // Finalize the SVG drawing and obtain the SvgImage object.
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file to the specified location.
                svgImage.Save(outputSvgPath);
            }
        }

        Console.WriteLine("SVG image created successfully at: " + outputSvgPath);
    }
}