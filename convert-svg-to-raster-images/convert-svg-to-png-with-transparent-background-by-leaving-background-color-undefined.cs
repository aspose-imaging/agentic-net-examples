// HOW-TO: Convert SVG to PNG with Transparent Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.Transparent,
                        PageSize = image.Size
                    }
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to embed vector icons from SVG files into a web page that requires PNG images with alpha transparency.
 * 2. When generating thumbnails for SVG diagrams in a desktop application that must preserve transparent backgrounds.
 * 3. When converting user‑uploaded SVG logos to PNG format for email signatures while keeping the background invisible.
 * 4. When preparing assets for a mobile app that only supports PNG images but the original graphics are in SVG with no background color.
 * 5. When automating a batch process that transforms SVG illustrations into PNG sprites for a game engine that expects transparent PNGs.
 */
