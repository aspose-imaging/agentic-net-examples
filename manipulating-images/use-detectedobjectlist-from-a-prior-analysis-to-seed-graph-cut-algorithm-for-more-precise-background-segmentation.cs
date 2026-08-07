using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\result.png";

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
 * 1. When a developer needs to verify that a source PNG file exists, load it with Aspose.Imaging, and automatically create the target folder before saving a copy in a new location.
 * 2. When an application must re‑encode an input PNG using Aspose.Imaging’s PngOptions to ensure a consistent output format.
 * 3. When a batch‑processing routine requires robust error handling to report missing files or I/O exceptions while loading and saving PNG images.
 * 4. When integrating Aspose.Imaging into a C# service that accepts user‑uploaded PNGs and stores processed versions in a server‑side directory hierarchy.
 * 5. When a developer wants to quickly prototype image duplication in .NET by loading a PNG, applying default processing, and writing the result to a subfolder with automatic directory creation.
 */