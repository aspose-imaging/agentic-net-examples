using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all PNG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.png");

            int total = inputFiles.Length;
            if (total == 0)
            {
                Console.WriteLine("No PNG files found to process.");
                return;
            }

            // Prepare save options with progressive encoding
            var saveOptions = new PngOptions
            {
                Progressive = true
            };

            for (int i = 0; i < total; i++)
            {
                string inputPath = inputFiles[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same file name in output directory)
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                // Ensure the output directory exists (unconditional as per rules)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Save with progressive PNG options
                    image.Save(outputPath, saveOptions);
                }

                // Update simple progress bar
                Console.Write($"\rProcessed {i + 1}/{total} images");
            }

            Console.WriteLine("\nProcessing completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a large collection of PNG assets to progressive PNGs for faster web loading while showing a console progress indicator.
 * 2. When an image processing pipeline must ensure all PNG files in a folder are saved with progressive encoding to reduce file size before uploading to a CDN.
 * 3. When a desktop application has to batch‑process user‑uploaded screenshots, applying Aspose.Imaging’s PngOptions and reporting real‑time progress in the console.
 * 4. When a migration script must move PNG images from a legacy directory to a new location, preserving filenames and providing feedback on how many files have been processed.
 * 5. When an automated build step requires validating that every PNG in a source folder can be loaded and saved with Aspose.Imaging, while displaying a simple progress bar to monitor job completion.
 */