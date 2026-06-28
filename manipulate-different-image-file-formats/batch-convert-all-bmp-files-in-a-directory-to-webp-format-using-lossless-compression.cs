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
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDir, "*.bmp", SearchOption.TopDirectoryOnly);

            foreach (string bmpFilePath in bmpFiles)
            {
                // Verify the BMP file exists
                if (!File.Exists(bmpFilePath))
                {
                    Console.Error.WriteLine($"File not found: {bmpFilePath}");
                    return;
                }

                // Determine output WebP file path
                string fileName = Path.GetFileNameWithoutExtension(bmpFilePath);
                string outputPath = Path.Combine(outputDir, fileName + ".webp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(bmpFilePath))
                {
                    // Save as lossless WebP
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true
                    };
                    image.Save(outputPath, webpOptions);
                }

                Console.WriteLine($"Converted: {bmpFilePath} -> {outputPath}");
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
 * 1. When a developer needs to migrate a legacy collection of BMP assets to modern, web‑optimized WebP files while preserving pixel‑perfect quality, they can use this code to batch convert the images with lossless compression.
 * 2. When an e‑commerce platform wants to reduce page load times by serving smaller image files, the script can automatically convert product BMP photos stored in a folder to lossless WebP before publishing.
 * 3. When a desktop application generates temporary BMP screenshots that must be archived efficiently, the batch converter can be run to transform those BMPs into lossless WebP files for long‑term storage.
 * 4. When a content management system needs to standardize uploaded graphics to a single format, this C# routine can process all BMP uploads in a directory and save them as WebP using Aspose.Imaging.
 * 5. When a CI/CD pipeline includes an image‑optimization step, the code can be invoked to ensure every BMP asset in the repository is converted to lossless WebP before the build is packaged.
 */