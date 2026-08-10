// HOW-TO: Convert EPS File to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "sample.eps";
            string outputPath = "result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image and save as PNG
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
 * 1. When you need to display vector EPS artwork on a web page that only supports raster PNG images.
 * 2. When an automated batch process must convert incoming EPS design files to PNG thumbnails for a content management system.
 * 3. When a desktop application imports EPS logos and saves them as PNGs to embed in PDF reports.
 * 4. When a server‑side service receives EPS files from users and must generate PNG previews for quick preview in a UI.
 * 5. When you are migrating legacy EPS assets to a modern image pipeline that requires PNG format for machine‑learning preprocessing.
 */
