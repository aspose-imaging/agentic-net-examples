// HOW-TO: Process Large Batch of High‑Resolution PNGs Without Out‑of‑Memory Errors in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base, input, and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Set a memory limit to avoid out‑of‑memory issues
                    var saveOptions = new PngOptions
                    {
                        BufferSizeHint = 100 // limit internal buffers to 100 MB
                    };

                    // Save the image with the specified options
                    image.Save(outputPath, saveOptions);
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
 * 1. When a C# application must resize or re‑encode thousands of 8K PNG photographs without crashing due to memory constraints.
 * 2. When an automated server process needs to generate thumbnails from a large collection of high‑resolution PNG assets while staying within limited RAM.
 * 3. When a desktop tool processes user‑uploaded PNG scans in batch and must prevent OutOfMemoryException on machines with modest memory.
 * 4. When a background service converts raw PNG files to optimized PNGs for web delivery and must limit buffer usage to avoid performance degradation.
 * 5. When a migration script moves PNG images between directories and applies Aspose.Imaging options to safely handle very large files.
 */
