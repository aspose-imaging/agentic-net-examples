// HOW-TO: Batch Convert TIFF Files to WebP with Timestamped Filenames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string outputPath = Path.Combine(outputDirectory, $"{fileNameWithoutExt}_{timestamp}.webp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new WebPOptions();
                    image.Save(outputPath, options);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When a developer needs to compress a large set of high‑resolution TIFF scans for faster web delivery, they can batch convert them to WebP and add a timestamp to avoid filename clashes.
 * 2. When an automated nightly job must archive newly received TIFF documents as space‑efficient WebP images while preserving the original capture time in the filename.
 * 3. When integrating a document management system that stores incoming TIFF files, a developer can use this code to generate timestamped WebP thumbnails for quick preview in a web UI.
 * 4. When migrating legacy medical imaging archives from TIFF to a modern format, the batch conversion with timestamped names ensures each converted file remains uniquely identifiable.
 * 5. When building a C# utility that processes user‑uploaded TIFF images and stores them in a CDN, adding a timestamp suffix guarantees unique WebP filenames across multiple uploads.
 */
