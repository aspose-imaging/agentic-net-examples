using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\input";
            string outputDirectory = @"C:\output";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                return;
            }

            // Get all PNG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.png", SearchOption.TopDirectoryOnly);
            int totalFiles = inputFiles.Length;
            if (totalFiles == 0)
            {
                Console.WriteLine("No PNG files found to process.");
                return;
            }

            // Process each file
            for (int i = 0; i < totalFiles; i++)
            {
                string inputPath = inputFiles[i];

                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Set progressive PNG options
                    var pngOptions = new PngOptions
                    {
                        Progressive = true
                    };

                    // Save the image with progressive option
                    image.Save(outputPath, pngOptions);
                }

                // Update progress bar
                int processed = i + 1;
                double percent = (processed / (double)totalFiles) * 100;
                Console.Write($"\rProcessed {processed}/{totalFiles} ({percent:0.##}%)");
            }

            // Move to next line after progress bar completes
            Console.WriteLine();
            Console.WriteLine("Batch processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert a large collection of PNG files to progressive PNG format using Aspose.Imaging in a C# console application and display a real‑time progress bar for each image processed.
 * 2. When an e‑commerce site must optimize product images for faster web loading by converting existing PNG assets to progressive PNGs while providing users with a visual progress indicator during the bulk operation.
 * 3. When a desktop utility is created to migrate legacy PNG resources to progressive PNGs for mobile apps, and the developer wants a command‑line progress bar that updates after each file is saved.
 * 4. When an automated CI/CD pipeline includes an image‑processing step that transforms PNG resources to progressive PNGs and requires a progress bar to monitor the batch conversion time.
 * 5. When a photographer’s workflow script processes hundreds of high‑resolution PNG photos with Aspose.Imaging and needs a progress bar to track the conversion status of each image.
 */