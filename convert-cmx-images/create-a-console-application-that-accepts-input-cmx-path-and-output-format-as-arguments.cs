// HOW-TO: Convert CMX to PNG Using Aspose.Imaging in C# Console App (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions();
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
 * 1. When a developer needs to batch‑convert CorelDRAW CMX files to web‑friendly PNG images for display on a website.
 * 2. When an automated build process must generate thumbnail previews of CMX drawings for a document management system.
 * 3. When a migration tool has to transform legacy CMX assets into PNG format to integrate with modern graphic pipelines.
 * 4. When a desktop utility must allow users to select a CMX file and instantly export it as a high‑quality PNG without opening CorelDRAW.
 * 5. When a server‑side service processes uploaded CMX files and stores them as PNGs for downstream image analysis or reporting.
 */
