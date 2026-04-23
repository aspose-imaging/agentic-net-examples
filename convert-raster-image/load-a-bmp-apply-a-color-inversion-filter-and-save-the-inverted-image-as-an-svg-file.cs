using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image as RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Load pixel data
            var bounds = raster.Bounds;
            int[] pixels = raster.LoadArgb32Pixels(bounds);

            // Invert colors (preserve alpha)
            for (int i = 0; i < pixels.Length; i++)
            {
                int argb = pixels[i];
                int alpha = argb & unchecked((int)0xFF000000);
                int rgb = argb & 0x00FFFFFF;
                int invertedRgb = (~rgb) & 0x00FFFFFF;
                pixels[i] = alpha | invertedRgb;
            }

            // Save modified pixels back to the raster image
            raster.SaveArgb32Pixels(bounds, pixels);

            // Create SVG graphics canvas with same dimensions
            var graphics = new SvgGraphics2D(raster.Width, raster.Height, 96);

            // Draw the raster image onto the SVG canvas
            graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(raster.Width, raster.Height));

            // Finalize SVG image and save
            using (SvgImage svgImage = graphics.EndRecording())
            {
                svgImage.Save(outputPath, new SvgOptions());
            }
        }
    }
}