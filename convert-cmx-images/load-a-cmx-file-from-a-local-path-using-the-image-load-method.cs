using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\temp\sample.cmx";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = @"C:\temp\sample.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                Console.WriteLine($"CMX image loaded. Width: {image.Width}, Height: {image.Height}");
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
                Console.WriteLine($"CMX image saved as PNG to {outputPath}");
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
 * 1. When a developer must use Aspose.Imaging.Image.Load to convert legacy CorelDRAW CMX vector files into PNG images for web preview.
 * 2. When an automated C# batch process reads CMX files from disk, obtains their width and height, and saves PNG thumbnails using PngOptions for a document management system.
 * 3. When a legacy CAD integration requires loading a CMX file with Image.Load to validate its dimensions before further processing.
 * 4. When a migration utility loads CMX artwork via Aspose.Imaging, converts it to PNG, and uploads the result to cloud storage for archival.
 * 5. When a desktop tool checks for a CMX file, loads it with CmxImage, and exports a PNG version for inclusion in a PowerPoint slide deck.
 */