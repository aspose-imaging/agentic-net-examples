using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG file path
        string inputJpgPath = @"C:\Temp\input.jpg";
        // Output SVGZ file path
        string outputSvgzPath = @"C:\Temp\output.svgz";

        // Load the JPG image as a raster image
        using (RasterImage jpgImage = (RasterImage)Image.Load(inputJpgPath))
        {
            // Create an SVG graphics canvas with the same dimensions as the JPG
            int width = jpgImage.Width;
            int height = jpgImage.Height;
            int dpi = 96; // standard screen DPI

            SvgGraphics2D svgGraphics = new SvgGraphics2D(width, height, dpi);

            // Draw the JPG onto the SVG canvas
            svgGraphics.DrawImage(jpgImage, new Point(0, 0), new Size(width, height));

            // Finalize the SVG image
            using (SvgImage svgImage = svgGraphics.EndRecording())
            {
                // Configure SVG options for compressed output (SVGZ)
                SvgOptions svgOptions = new SvgOptions
                {
                    Compress = true
                };

                // Save the SVGZ file
                svgImage.Save(outputSvgzPath, svgOptions);
            }
        }
    }
}