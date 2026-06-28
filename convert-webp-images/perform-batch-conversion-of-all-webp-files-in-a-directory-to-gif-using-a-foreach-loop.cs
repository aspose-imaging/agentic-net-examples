using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\input\";
            string outputDirectory = @"C:\output\";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all WebP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDirectory, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output GIF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image and save as GIF
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new GifOptions());
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
 * 1. When a developer needs to convert an entire folder of WebP images to GIF format for compatibility with legacy web browsers, they can use this batch conversion loop.
 * 2. When automating the preparation of animated assets for email newsletters that only support GIF, the code can process all WebP files in a directory and save them as GIFs.
 * 3. When migrating a digital asset library from modern WebP files to a universally supported GIF format for a content management system, this foreach‑based converter streamlines the task.
 * 4. When building a scheduled job that nightly transforms newly uploaded WebP pictures into GIFs for a mobile app that only renders GIF animations, the sample demonstrates the required file‑system and image‑processing steps.
 * 5. When creating a command‑line utility that allows users to select an input folder and receive GIF versions of every WebP file for offline viewing, the code provides the core batch processing logic.
 */