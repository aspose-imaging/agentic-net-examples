// HOW-TO: Batch Convert All WebP Files to GIF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "C:\\WebPInput\\";
            string outputDir = "C:\\GifOutput\\";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Process each WebP file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDir, "*.webp"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding GIF output path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".gif");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image and save it as GIF
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    webPImage.Save(outputPath, new GifOptions());
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
 * 1. When you need to automatically transform a folder of WebP assets into GIFs for web animation compatibility.
 * 2. When a migration script must process thousands of WebP images on a server and save them as GIFs without manual intervention.
 * 3. When an e‑commerce platform wants to generate GIF previews from user‑uploaded WebP product photos in bulk.
 * 4. When a desktop utility has to read WebP files from a directory, convert each to GIF, and store them in a separate output folder.
 * 5. When a CI/CD pipeline requires a step that converts all WebP test images to GIF format for legacy reporting tools.
 */
