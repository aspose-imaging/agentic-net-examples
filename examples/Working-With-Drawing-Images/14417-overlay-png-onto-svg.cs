using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Folder containing the source SVG and PNG files
        string dir = @"C:\temp\";

        // Paths to the existing SVG and the PNG to be drawn on it
        string svgPath = System.IO.Path.Combine(dir, "source.svg");
        string pngPath = System.IO.Path.Combine(dir, "overlay.png");
        string outputPath = System.IO.Path.Combine(dir, "result.svg");

        // Load the existing SVG image
        using (SvgImage svgImage = new SvgImage(svgPath))
        {
            // Load the PNG image as a raster image
            using (RasterImage pngImage = (RasterImage)Image.Load(pngPath))
            {
                // Create a graphics object that operates on the loaded SVG
                SvgGraphics2D graphics = new SvgGraphics2D(svgImage);

                // Draw the PNG onto the SVG at the desired location (e.g., (50,50))
                graphics.DrawImage(pngImage, new Point(50, 50));

                // Finalize the drawing and obtain the updated SVG image
                using (SvgImage resultSvg = graphics.EndRecording())
                {
                    // Save the modified SVG to disk
                    resultSvg.Save(outputPath);
                }
            }
        }
    }
}