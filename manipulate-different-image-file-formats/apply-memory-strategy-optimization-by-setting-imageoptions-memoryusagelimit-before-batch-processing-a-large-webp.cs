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
            string inputDir = "C:\\WebPInput\\";
            string outputDir = "C:\\WebPOutput\\";

            // Get all WebP files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.webp");

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the corresponding output PNG path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image with a memory usage limit (BufferSizeHint in MB)
                using (Image image = Image.Load(inputPath, new LoadOptions { BufferSizeHint = 50 }))
                {
                    // Save the image as PNG
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert a large batch of WebP images to PNG format on a Windows server while preventing excessive memory consumption.
 * 2. When an e‑commerce platform must generate high‑quality PNG thumbnails from user‑uploaded WebP product photos without exhausting the application pool memory.
 * 3. When a desktop utility processes thousands of WebP assets for a game and must limit the buffer size to keep the process within a 50 MB memory budget.
 * 4. When a cloud‑based image pipeline migrates legacy WebP files to PNG for compatibility with older browsers and wants to enforce a memory usage cap during the conversion.
 * 5. When an automated build script prepares image resources for a mobile app, converting WebP to PNG while ensuring the conversion runs reliably on machines with limited RAM.
 */