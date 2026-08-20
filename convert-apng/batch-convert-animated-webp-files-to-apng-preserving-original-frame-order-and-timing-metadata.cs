// HOW-TO: Batch Convert Animated WebP Files to APNG with Frame Timing in C# (Aspose.Imaging for .NET)
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
            string inputDir = @"C:\InputWebp";
            string outputDir = @"C:\OutputApng";

            // Ensure output directory exists (creates if missing)
            Directory.CreateDirectory(outputDir);

            // Get all animated WEBP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDir, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (same name with .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists (handles subfolders if any)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the animated WEBP image and save it as APNG
                using (Image image = Image.Load(inputPath))
                {
                    // Save using default ApngOptions to preserve frame order and timing
                    image.Save(outputPath, new ApngOptions());
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
 * 1. When you need to migrate a collection of animated WebP assets to APNG for better browser compatibility while keeping the original animation speed.
 * 2. When an e‑learning platform requires converting user‑uploaded animated WebP stickers into APNGs for consistent playback across iOS devices.
 * 3. When a game developer wants to batch process sprite animations stored as WebP into APNGs to use with a framework that only supports PNG sequences.
 * 4. When a marketing team automates the conversion of animated product demos from WebP to APNG to embed them in email newsletters that support APNG.
 * 5. When a CI/CD pipeline must ensure all animated WebP files in a repository are transformed into APNGs with preserved frame order before deployment.
 */
