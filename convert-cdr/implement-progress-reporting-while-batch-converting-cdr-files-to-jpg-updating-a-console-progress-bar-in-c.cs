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
            // Define input and output directories relative to the current directory
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");

            // Ensure input directory exists
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all CDR files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.cdr");
            int totalFiles = files.Length;
            int processedCount = 0;

            foreach (var inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".jpg");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image with a progress handler
                var loadOptions = new LoadOptions
                {
                    ProgressEventHandler = info =>
                    {
                        // Simple per‑file load progress display
                        Console.Write($"\rLoading {fileName}: {info.EventType} {info.Value}/{info.MaxValue}");
                    }
                };

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    // Save as JPEG with a progress handler
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 90,
                        ProgressEventHandler = info =>
                        {
                            // Simple per‑file save progress display
                            Console.Write($"\rSaving {fileName}: {info.EventType} {info.Value}/{info.MaxValue}   ");
                        }
                    };

                    image.Save(outputPath, jpegOptions);
                }

                // Move to the next line after progress output
                Console.WriteLine();

                processedCount++;
                // Overall batch progress
                Console.WriteLine($"Processed {processedCount}/{totalFiles}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}