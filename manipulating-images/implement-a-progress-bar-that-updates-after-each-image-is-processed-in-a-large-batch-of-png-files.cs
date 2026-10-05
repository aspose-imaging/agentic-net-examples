// HOW-TO: How to Process a Large Batch of PNG Files with Progress Bar in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchPngProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "InputImages";
                string outputDirectory = "OutputImages";

                // Get all PNG files in the input directory
                string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png", SearchOption.TopDirectoryOnly);
                int totalFiles = pngFiles.Length;

                if (totalFiles == 0)
                {
                    Console.WriteLine("No PNG files found to process.");
                    return;
                }

                for (int i = 0; i < totalFiles; i++)
                {
                    string inputPath = pngFiles[i];

                    // Input file existence check
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Load the PNG image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Prepare output path
                        string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the image (could apply processing here if needed)
                        var pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
                    }

                    // Update progress bar
                    int processed = i + 1;
                    int percent = (int)((processed / (double)totalFiles) * 100);
                    Console.Write($"\rProgress: {percent}% ({processed}/{totalFiles})");
                }

                // Move to next line after completion
                Console.WriteLine();
                Console.WriteLine("Batch processing completed.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert or copy thousands of PNG images to another folder while showing users how many files have been processed.
 * 2. When you want to integrate Aspose.Imaging into a C# console app to batch‑resize or apply filters to PNG files and keep the UI responsive with a progress indicator.
 * 3. When an automated build or deployment script must verify the existence of each PNG, load it with Aspose.Imaging, and log progress for monitoring.
 * 4. When a desktop utility must ensure the output directory exists before saving each processed PNG and display percentage completion to avoid guessing runtime duration.
 * 5. When you are creating a data‑migration tool that moves PNG assets between storage locations and need real‑time feedback on processing status for large image sets.
 */
