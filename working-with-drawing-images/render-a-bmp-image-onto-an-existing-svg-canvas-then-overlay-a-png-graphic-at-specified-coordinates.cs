using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string svgInputPath = "input.svg";
        string bmpInputPath = "overlay.bmp";
        string pngOverlayPath = "overlay.png";
        string outputSvgPath = "output.svg";

        // Verify input files exist
        if (!File.Exists(svgInputPath))
        {
            Console.Error.WriteLine($"File not found: {svgInputPath}");
            return;
        }
        if (!File.Exists(bmpInputPath))
        {
            Console.Error.WriteLine($"File not found: {bmpInputPath}");
            return;
        }
        if (!File.Exists(pngOverlayPath))
        {
            Console.Error.WriteLine($"File not found: {pngOverlayPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));

        // Load the existing SVG canvas
        using (SvgImage svgImage = new SvgImage(svgInputPath))
        {
            // Create a graphics object for drawing on the SVG
            SvgGraphics2D graphics = new SvgGraphics2D(svgImage);

            // Load BMP image and draw it onto the SVG at (0,0)
            using (RasterImage bmpImage = (RasterImage)Image.Load(bmpInputPath))
            {
                graphics.DrawImage(bmpImage, new Aspose.Imaging.Point(0, 0));
            }

            // Load PNG image and overlay it at specified coordinates (e.g., 100,100)
            using (RasterImage pngImage = (RasterImage)Image.Load(pngOverlayPath))
            {
                graphics.DrawImage(pngImage, new Aspose.Imaging.Point(100, 100));
            }

            // Finalize drawing and obtain the resulting SVG image
            using (SvgImage resultSvg = graphics.EndRecording())
            {
                // Save the modified SVG to the output path
                resultSvg.Save(outputSvgPath);
            }
        }
    }
}