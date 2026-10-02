// HOW-TO: Batch Compress GIF Files and Log Size Reduction in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

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

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (GifOptions options = new GifOptions())
                    {
                        image.Save(outputPath, options);
                    }
                }

                long originalSize = new FileInfo(inputPath).Length;
                long compressedSize = new FileInfo(outputPath).Length;
                Console.WriteLine($"File: {fileName}, Original: {originalSize} bytes, Compressed: {compressedSize} bytes");
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
 * 1. When you need to reduce the storage footprint of a large collection of GIF animations before uploading them to a web server.
 * 2. When you want to generate a report of original versus compressed file sizes to evaluate the effectiveness of GIF optimization.
 * 3. When you are building an automated pipeline that processes user‑uploaded GIFs and saves the optimized versions to a separate output folder.
 * 4. When you need to compare different compression settings by repeatedly saving GIFs with Aspose.Imaging and tracking size changes.
 * 5. When you are creating a desktop utility that scans a directory, compresses all GIFs, and logs the results for performance monitoring.
 */
