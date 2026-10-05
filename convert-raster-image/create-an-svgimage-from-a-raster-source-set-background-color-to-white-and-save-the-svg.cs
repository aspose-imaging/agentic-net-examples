// HOW-TO: Convert PNG to SVG with White Background Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\source.png";
        string outputPath = "Output\\result.svg";

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
                using (SvgOptions options = new SvgOptions())
                {
                    options.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

                    image.Save(outputPath, options);
                }
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
 * 1. When you need to embed a raster logo in an SVG file for responsive web design while ensuring a consistent white backdrop.
 * 2. When generating printable vector graphics from user‑uploaded PNG images for a reporting system that requires a solid background.
 * 3. When converting product photos to scalable SVG assets for a mobile app that scales images without losing quality.
 * 4. When automating batch processing of scanned PNG documents into SVG format with a white canvas for archival purposes.
 * 5. When creating SVG placeholders from PNG thumbnails in a content‑management workflow that demands a uniform background color.
 */
