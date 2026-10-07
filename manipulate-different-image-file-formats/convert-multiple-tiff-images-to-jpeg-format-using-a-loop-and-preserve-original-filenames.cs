// HOW-TO: Batch Convert TIFF Files to JPEG While Keeping Original Filenames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

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
                .Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        jpegOptions.Source = new FileCreateSource(outputPath, false);
                        image.Save();
                    }
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
 * 1. When a photo‑archiving system receives scanned TIFF documents and must generate web‑ready JPEGs without altering the original file names.
 * 2. When a medical imaging workflow needs to export a batch of high‑resolution TIFF scans to compressed JPEGs for quick preview while keeping the naming convention for patient records.
 * 3. When an e‑commerce platform wants to transform product catalog TIFF images into JPEG thumbnails automatically during nightly processing, preserving the SKU‑based filenames.
 * 4. When a GIS application requires converting large sets of satellite TIFF tiles to JPEG format for faster map rendering, maintaining the tile identifiers.
 * 5. When a document management solution automates the migration of legacy TIFF files to JPEG for storage optimization, ensuring each file retains its original name for traceability.
 */
