using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\WebPInput\";
            string outputDir = @"C:\WebPOutput\";

            // Ensure the output root folder exists
            Directory.CreateDirectory(outputDir);

            // Get all WebP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDir, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set a memory usage limit via BufferSizeHint (in megabytes)
                var loadOptions = new LoadOptions { BufferSizeHint = 100 }; // limit internal buffers to 100 MB

                // Load the WebP image with the specified memory limit
                using (WebPImage webPImage = new WebPImage(inputPath, loadOptions))
                {
                    // Save the image as PNG
                    webPImage.Save(outputPath, new PngOptions());
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
 * 1. When a C# web service must convert thousands of user‑uploaded WebP photos to PNG for compatibility with legacy browsers while preventing out‑of‑memory crashes by using ImageOptions.MemoryUsageLimit.
 * 2. When an automated build pipeline processes a large archive of product images stored as WebP and needs to generate PNG thumbnails on a CI server with limited RAM.
 * 3. When a desktop utility written in .NET migrates a legacy asset library from WebP to PNG for a print workflow, and the developer wants to cap internal buffers to avoid excessive memory consumption.
 * 4. When a cloud‑based image‑processing function receives a batch of WebP files from a storage bucket and must safely convert them to PNG within the memory quota of a serverless container.
 * 5. When a Windows service monitors a folder for new WebP files, converts each to PNG for downstream analytics, and uses the BufferSizeHint setting to keep the process stable on low‑memory machines.
 */