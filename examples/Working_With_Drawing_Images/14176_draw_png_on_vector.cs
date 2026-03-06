using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define paths
        string dir = @"c:\temp\";
        string pngPath = Path.Combine(dir, "sample.png");
        string outputSvgPath = Path.Combine(dir, "output.svg");

        // Load the raster PNG image
        using (RasterImage rasterPng = (RasterImage)Image.Load(pngPath))
        {
            // Create an SVG graphics context with desired dimensions and DPI
            int svgWidth = 800;
            int svgHeight = 600;
            int dpi = 96;
            var svgGraphics = new SvgGraphics2D(svgWidth, svgHeight, dpi);

            // Optional: draw a border around the SVG canvas
            svgGraphics.DrawRectangle(
                new Pen(Color.Black, 1),
                0, 0, svgWidth, svgHeight);

            // Draw the loaded PNG onto the SVG at position (100,100) with size 200x150
            svgGraphics.DrawImage(
                rasterPng,
                new Point(100, 100),
                new Size(200, 150));

            // Finalize the SVG image
            using (SvgImage svgImage = svgGraphics.EndRecording())
            {
                // Save the resulting SVG file
                svgImage.Save(outputSvgPath);
            }
        }
    }
}