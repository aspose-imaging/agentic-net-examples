// HOW-TO: Remove Background from SVG and Save as PNG Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (SvgImage image = (SvgImage)Image.Load(inputPath))
            {
                image.RemoveBackground();
                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate transparent PNG icons from SVG artwork for web UI, you can load the SVG, strip its background, and export it as PNG with Aspose.Imaging in C#.
 * 2. When preparing product images for e‑commerce, you can automatically remove the solid background from vector logos and save them as PNG files for use on catalog pages.
 * 3. When creating assets for mobile apps, you can convert SVG illustrations to PNG with a transparent background to ensure they render correctly on different screen sizes.
 * 4. When automating a design pipeline, you can batch‑process SVG files to eliminate their backgrounds and output PNGs without manual editing, using C# and Aspose.Imaging.
 * 5. When integrating vector graphics into a reporting system, you can strip the SVG background and embed the resulting PNG with transparency into PDF or HTML reports.
 */
