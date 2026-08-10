// HOW-TO: Batch Convert CDR to JPG with Console Progress Bar in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ProgressManagement;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Base directories
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

            // Get all files in input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string filePath in files)
            {
                // Process only CDR files
                if (!Path.GetExtension(filePath).Equals(".cdr", StringComparison.OrdinalIgnoreCase))
                    continue;

                string inputPath = filePath;

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load options with progress handler
                var loadOptions = new LoadOptions
                {
                    ProgressEventHandler = info =>
                        Console.WriteLine($"Loading {Path.GetFileName(inputPath)}: {info.EventType} {info.Value}/{info.MaxValue}")
                };

                // Save options with progress handler
                using (var jpegOptions = new JpegOptions
                {
                    ProgressEventHandler = info =>
                        Console.WriteLine($"Saving {Path.GetFileName(outputPath)}: {info.EventType} {info.Value}/{info.MaxValue}")
                })
                // Load CDR image
                using (var image = Image.Load(inputPath, loadOptions))
                {
                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to convert many CorelDRAW (.cdr) files to JPEG images automatically and see conversion progress in the console.
 * 2. When a command‑line tool must create an output folder structure and ensure it exists before processing each file.
 * 3. When you want to skip non‑CDR files in a directory while batch processing only the supported format.
 * 4. When you require error handling that reports missing input files and stops the conversion gracefully.
 * 5. When you want to generate JPEG filenames that match the original CDR names and store them in a separate output directory.
 */
