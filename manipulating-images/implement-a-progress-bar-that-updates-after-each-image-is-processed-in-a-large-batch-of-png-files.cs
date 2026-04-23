using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ProgressManagement;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                return;
            }

            // Get all PNG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.png", SearchOption.AllDirectories);
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

                // Determine output path preserving relative structure
                string relativePath = Path.GetRelativePath(inputDirectory, inputPath);
                string outputPath = Path.Combine(outputDirectory, relativePath);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Set progressive option for PNG saving
                    var pngOptions = new PngOptions
                    {
                        Progressive = true,
                        // Optional: you can set other options like CompressionLevel if desired
                        CompressionLevel = 9
                    };

                    // Save the image with progressive PNG options
                    image.Save(outputPath, pngOptions);
                }

                // Update simple progress bar
                Console.Write($"\rProcessed {i + 1}/{totalFiles} files");
            }

            // Move to next line after progress bar completes
            Console.WriteLine("\nProcessing completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}