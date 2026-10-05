// HOW-TO: Convert SVG to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svg = (SvgImage)image;
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                svg.Save(outputPath, pngOptions);
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
 * 1. When you need to generate PNG thumbnails from SVG logos for a web application using C#.
 * 2. When you want to batch‑convert a collection of SVG icons into PNG assets for mobile apps without custom rasterization settings.
 * 3. When you must embed vector diagrams into PDF reports that only accept PNG images, requiring an automated SVG‑to‑PNG conversion.
 * 4. When you are building a CI pipeline that transforms designer‑provided SVG files into PNGs for automated UI testing.
 * 5. When you need to store user‑uploaded SVG artwork as PNG files to ensure compatibility with legacy browsers and image viewers.
 */
