using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = { "image1.svg", "image2.svg" };
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.ChangeExtension(inputPath, ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a batch of SVG vector graphics to PNG raster images for web display, they can use this code to load each SVG with Aspose.Imaging and save it as PNG.
 * 2. When an automated build process must ensure that all SVG assets are available as PNG thumbnails for a mobile app, this snippet checks file existence, creates output folders, and performs the conversion.
 * 3. When a server‑side C# service has to generate PNG previews of user‑uploaded SVG files while handling missing files gracefully, the example demonstrates the required try‑catch and error logging.
 * 4. When a CI/CD pipeline needs to validate that SVG icons are correctly rendered as PNGs before publishing a design system, the code provides a simple loop to load each SVG with Aspose.Imaging and save it using PngOptions.
 * 5. When a desktop utility must batch‑process vector illustrations into PNGs for printing or documentation, this program shows how to read SVG files, create the destination directory, and convert them using Aspose.Imaging in .NET.
 */