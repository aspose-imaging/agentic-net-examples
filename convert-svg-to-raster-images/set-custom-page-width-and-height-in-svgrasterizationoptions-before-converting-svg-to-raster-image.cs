// HOW-TO: Set Custom Page Size for SVG to PNG Conversion in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = 800,
                    PageHeight = 600
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                svgImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a PNG thumbnail of an SVG at a specific resolution for a web gallery.
 * 2. When you must ensure the rasterized image fits exact dimensions for printing or PDF embedding.
 * 3. When you are creating responsive UI assets and need consistent width and height across devices.
 * 4. When you want to batch‑process SVG icons and enforce a uniform canvas size before saving as PNG.
 * 5. When you are integrating SVG graphics into a game engine that requires textures of predefined pixel dimensions.
 */
