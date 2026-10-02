// HOW-TO: Batch Convert TIFF Files to WebP Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var inputPath in files)
            {
                if (!inputPath.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) && !inputPath.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (WebPOptions options = new WebPOptions())
                    {
                        image.Save(outputPath, options);
                    }
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
 * 1. When you need to reduce storage size of scanned documents by converting TIFF scans to WebP for web delivery.
 * 2. When you want to automate conversion of a large collection of medical imaging TIFF files to WebP thumbnails in a C# backend.
 * 3. When you are building an image optimization pipeline that processes all TIFF assets in a folder and outputs WebP for faster page loads.
 * 4. When you need to migrate legacy TIFF assets to a modern web‑friendly format without manual handling, using Aspose.Imaging in a .NET service.
 * 5. When you are creating a batch script to prepare product catalog images originally in TIFF for e‑commerce sites that require WebP.
 */
