using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputDir);

            // Get all PNG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.png");

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine corresponding output path
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDir, fileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                try
                {
                    // Load the PNG image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Set a memory limit to mitigate out‑of‑memory issues
                        var saveOptions = new PngOptions
                        {
                            BufferSizeHint = 200 // limit internal buffers to 200 MB
                        };

                        // Save the image to the output location using the specified options
                        image.Save(outputPath, saveOptions);
                    }
                }
                catch (PngImageException ex)
                {
                    Console.Error.WriteLine($"PngImageException processing {inputPath}: {ex.Message}");
                }
                catch (OutOfMemoryException ex)
                {
                    Console.Error.WriteLine($"Out of memory processing {inputPath}: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error processing {inputPath}: {ex.Message}");
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
 * 1. When a photo‑editing service needs to convert thousands of high‑resolution PNG assets to a standardized format without crashing due to memory limits.
 * 2. When a medical imaging application processes large PNG scans in batch and must prevent out‑of‑memory exceptions on a server with limited RAM.
 * 3. When an e‑commerce platform generates product thumbnails from high‑resolution PNG files overnight and wants to ensure the batch job completes reliably.
 * 4. When a GIS tool re‑projects and saves massive PNG map tiles and needs to cap internal buffers to avoid memory overflow.
 * 5. When a digital archiving system migrates legacy PNG documents to a new storage location and must handle occasional missing files while protecting against memory exhaustion.
 */