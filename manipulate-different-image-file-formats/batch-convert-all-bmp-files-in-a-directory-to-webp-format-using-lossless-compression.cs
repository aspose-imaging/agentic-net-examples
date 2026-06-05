using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = "C:\\Images\\Input";
        string outputDirectory = "C:\\Images\\Output";

        try
        {
            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output file path with .webp extension
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as lossless WebP
                    image.Save(
                        outputPath,
                        new WebPOptions { Lossless = true });
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
 * 1. When a developer must migrate a legacy folder of BMP graphics to WebP for faster web page loading while keeping lossless image quality, this batch conversion code automates the process.
 * 2. When an e‑commerce platform needs to convert user‑uploaded BMP product photos to WebP to reduce bandwidth usage without sacrificing detail, the code provides a C# solution using Aspose.Imaging.
 * 3. When a game studio wants to archive its BMP sprite assets as smaller WebP files for distribution builds, the script iterates through directories and saves each image losslessly.
 * 4. When a content management system requires periodic batch conversion of BMP icons to WebP to comply with modern browser standards, the example demonstrates the necessary file I/O and image‑format handling in .NET.
 * 5. When a developer is building an automated build pipeline that transforms design‑team BMP mockups into WebP assets for responsive design, this code shows how to load, convert, and save images programmatically.
 */