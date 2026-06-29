using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string? outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Load the EPS image and save it as PNG
            using (var image = Image.Load(inputPath))
            {
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy EPS vector graphics from a design repository into PNG raster images for web display in a C# application.
 * 2. When an automated build script must batch‑process EPS files stored on disk and generate PNG thumbnails for a content management system using Aspose.Imaging for .NET.
 * 3. When a Windows service has to validate the existence of an EPS file, load it, and save it as a PNG to ensure compatibility with downstream image processing pipelines.
 * 4. When a desktop utility needs to let users select an EPS logo file and instantly export it to PNG format for inclusion in reports or presentations.
 * 5. When a migration tool must read EPS artwork from a legacy file system and convert it to PNG while handling missing files and creating output directories programmatically.
 */