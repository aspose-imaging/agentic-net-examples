// HOW-TO: Convert CDR to PNG with Maximum Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.cdr";
        string outputPath = "Output\\sample.png";

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
                var pngOptions = new PngOptions
                {
                    PngCompressionLevel = PngCompressionLevel.ZipLevel9
                };
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
 * 1. When a designer needs to embed CorelDRAW (CDR) graphics into a web page and wants the smallest possible PNG files for faster loading.
 * 2. When an automated build pipeline must batch‑convert CDR assets to PNG while applying the highest ZIP compression to meet storage quotas.
 * 3. When a desktop application processes user‑uploaded CDR files and must save them as PNGs with maximum compression to reduce disk usage.
 * 4. When a reporting tool generates PNG charts from CDR templates and requires the images to be as compact as possible for email attachments.
 * 5. When a migration script moves legacy CDR artwork to a PNG‑based asset library and needs to preserve visual fidelity while minimizing file size.
 */
