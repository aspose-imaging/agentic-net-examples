using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputSvgPath = "input.svg";
        string inputPngPath = "image.png";
        string outputSvgPath = "output.svg";

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

        // Load the source SVG to obtain its dimensions
        using (SvgImage sourceSvg = new SvgImage(inputSvgPath))
        {
            int canvasWidth = sourceSvg.Width;
            int canvasHeight = sourceSvg.Height;
            int dpi = 96; // Standard screen DPI

            // Create a new SVG canvas with the same size as the source SVG
            SvgGraphics2D graphics = new SvgGraphics2D(canvasWidth, canvasHeight, dpi);

            // Optionally, copy existing SVG content onto the new canvas
            // (If you need to preserve original SVG elements, you could render the source SVG onto the graphics.
            // For simplicity, this example starts with a blank canvas.)

            // Load the raster PNG image
            using (RasterImage rasterImg = (RasterImage)Image.Load(inputPngPath))
            {
                // Define where the PNG should be placed on the SVG canvas
                // Here we place it at (50, 50) with its original size
                int posX = 50;
                int posY = 50;
                graphics.DrawImage(rasterImg, new Aspose.Imaging.Point(posX, posY));
            }

            // Finalize the SVG image
            using (SvgImage resultSvg = graphics.EndRecording())
            {
                // Save the resulting SVG
                resultSvg.Save(outputSvgPath);
            }
        }
    }
}