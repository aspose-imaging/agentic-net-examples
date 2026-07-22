using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string bmpFilePath in bmpFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(bmpFilePath))
                {
                    Console.Error.WriteLine($"File not found: {bmpFilePath}");
                    return;
                }

                // Determine the output file path with .webp extension
                string outputFilePath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(bmpFilePath) + ".webp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

                // Load the BMP image
                using (Image image = Image.Load(bmpFilePath))
                {
                    // Save as lossless WebP
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true
                    };
                    image.Save(outputFilePath, webpOptions);
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
 * 1. When a developer needs to reduce storage costs by converting a folder of legacy BMP assets to lossless WebP files for faster web delivery.
 * 2. When an image processing pipeline must automatically migrate user‑uploaded BMP screenshots to WebP format without quality loss before archiving.
 * 3. When a desktop application has to generate WebP thumbnails from a batch of BMP design files to improve loading speed in a gallery view.
 * 4. When a migration script is required to replace BMP icons in a Windows application with WebP equivalents while preserving exact pixel data.
 * 5. When a CI/CD build step must ensure all BMP resources in a project are converted to lossless WebP to meet modern web standards.
 */