// HOW-TO: Process Large PNG Batch With OutOfMemory Handling In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (var inputPath in files)
            {
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                try
                {
                    using (Image image = Image.Load(inputPath))
                    {
                        var options = new PngOptions
                        {
                            BufferSizeHint = 1024 * 1024
                        };
                        image.Save(outputPath, options);
                    }
                }
                catch (OutOfMemoryException)
                {
                    Console.Error.WriteLine($"Out of memory processing file: {inputPath}. Skipping.");
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error processing file {inputPath}: {ex.Message}");
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
 * 1. When you need to convert or re‑save thousands of high‑resolution PNG images on a server without crashing due to memory limits.
 * 2. When an automated image‑processing pipeline must skip oversized PNG files that exceed available RAM and continue processing the rest.
 * 3. When you want to apply Aspose.Imaging’s PNG options such as BufferSizeHint to improve streaming performance for large images.
 * 4. When a desktop application processes user‑uploaded PNG photos and must gracefully recover from OutOfMemoryException.
 * 5. When a scheduled job generates thumbnails from a massive PNG collection and must free memory after each file to avoid leaks.
 */
