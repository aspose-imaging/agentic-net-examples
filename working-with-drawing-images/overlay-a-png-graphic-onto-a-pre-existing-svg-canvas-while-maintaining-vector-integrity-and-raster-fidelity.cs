using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputSvgPath = @"C:\Images\canvas.svg";
        string inputPngPath = @"C:\Images\overlay.png";
        string outputSvgPath = @"C:\Images\result.svg";

        // Verify SVG input exists
        if (!File.Exists(inputSvgPath))
        {
            Console.Error.WriteLine($"File not found: {inputSvgPath}");
            return;
        }

        // Verify PNG input exists
        if (!File.Exists(inputPngPath))
        {
            Console.Error.WriteLine($"File not found: {inputPngPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));

        // Load SVG canvas
        using (SvgImage svgImage = (SvgImage)Image.Load(inputSvgPath))
        {
            // Load PNG graphic
            using (RasterImage pngImage = (RasterImage)Image.Load(inputPngPath))
            {
                // Create graphics object bound to existing SVG
                SvgGraphics2D graphics = new SvgGraphics2D(svgImage);

                // Draw PNG onto SVG at position (0,0) with original size
                graphics.DrawImage(pngImage, new Point(0, 0), new Size(pngImage.Width, pngImage.Height));

                // Finalize SVG image
                using (SvgImage resultSvg = graphics.EndRecording())
                {
                    // Save the combined SVG
                    resultSvg.Save(outputSvgPath);
                }
            }
        }
    }
}