// HOW-TO: Convert SVG to PNG with Maximum Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

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

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;
                PngOptions options = new PngOptions
                {
                    CompressionLevel = (int)PngCompressionLevel.ZipLevel9,
                    Source = new FileCreateSource(outputPath, false)
                };
                svgImage.Save(outputPath, options);
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
 * 1. When you need to generate web‑ready PNG thumbnails from vector SVG logos while keeping the file size as small as possible.
 * 2. When you are preparing assets for mobile apps and must shrink PNG images without losing the original SVG quality.
 * 3. When an e‑commerce platform converts product SVG diagrams to compressed PNGs for faster page loads.
 * 4. When a reporting service exports SVG charts as PNG files and wants to minimize bandwidth usage by using the highest ZIP compression level.
 * 5. When a batch‑processing job automates conversion of a large SVG library to PNG and requires maximum compression to save disk space.
 */
