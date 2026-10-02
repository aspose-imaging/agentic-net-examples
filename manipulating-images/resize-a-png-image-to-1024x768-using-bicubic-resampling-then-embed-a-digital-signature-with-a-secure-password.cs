// HOW-TO: Resize PNG to 1024x768 Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Resize(1024, 768, ResizeType.NearestNeighbourResample);

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, options);
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
 * 1. When you need to standardize user‑uploaded PNG photos to 1024×768 before storing them on a server.
 * 2. When generating preview images for a desktop application that requires all PNG assets to have the same resolution.
 * 3. When preparing PNG graphics for a PDF report where the layout expects a fixed 1024×768 size.
 * 4. When optimizing PNG files for a slideshow that only supports 1024×768 resolution on the target display.
 * 5. When converting high‑resolution PNG scans to a uniform size for batch processing in an automated C# workflow.
 */
