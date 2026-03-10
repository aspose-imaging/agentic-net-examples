using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Paths to the source SVG, the PNG to overlay, and the output SVG.
        string dir = @"c:\temp\";
        string svgPath = System.IO.Path.Combine(dir, "input.svg");
        string pngPath = System.IO.Path.Combine(dir, "overlay.png");
        string outPath = System.IO.Path.Combine(dir, "output.svg");

        // Load the existing SVG image.
        using (SvgImage svgImage = new SvgImage(svgPath))
        {
            // Create a graphics object that draws onto the loaded SVG.
            using (SvgGraphics2D graphics = new SvgGraphics2D(svgImage))
            {
                // Load the PNG image as a raster image.
                using (RasterImage pngImage = (RasterImage)Image.Load(pngPath))
                {
                    // Draw the PNG onto the SVG at the desired location (e.g., (50,50)).
                    // The image is drawn with its original dimensions.
                    graphics.DrawImage(pngImage, new Aspose.Imaging.Point(50, 50));
                }

                // Finalize drawing and obtain the updated SVG image.
                using (SvgImage resultSvg = graphics.EndRecording())
                {
                    // Save the modified SVG to disk.
                    resultSvg.Save(outPath);
                }
            }
        }
    }
}