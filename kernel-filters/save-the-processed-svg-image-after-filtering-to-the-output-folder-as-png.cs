// HOW-TO: Convert Filtered SVG to PNG and Save to Folder in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace SvgToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.svg";
                string outputPath = "output/processed.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Cast to SvgImage if needed for further processing
                    // (e.g., apply filters here)

                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate high‑quality PNG thumbnails from SVG assets after applying custom filters in a C# web service.
 * 2. When an automated build pipeline must convert processed SVG logos into PNG files for inclusion in mobile app resources.
 * 3. When a desktop application requires saving user‑edited vector graphics as raster PNGs for printing or email attachment.
 * 4. When a batch job processes a folder of SVG diagrams, applies transformations, and stores the resulting PNGs in a designated output directory.
 * 5. When integrating Aspose.Imaging into a C# microservice to render filtered SVG charts as PNG images for API responses.
 */
