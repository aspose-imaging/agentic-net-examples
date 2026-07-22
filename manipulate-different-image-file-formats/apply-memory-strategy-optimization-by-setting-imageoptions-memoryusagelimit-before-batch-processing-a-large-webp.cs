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
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

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

                // Build the corresponding output file path (PNG format)
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set a memory usage limit (buffer size hint) for loading the image
                var loadOptions = new LoadOptions { BufferSizeHint = 100 }; // limit to 100 MB

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
 * 1. When a developer needs to batch‑convert a large collection of WebP images to PNG for broader compatibility while enforcing a memory‑usage limit to prevent out‑of‑memory crashes.
 * 2. When an automated C# image‑processing pipeline must load high‑resolution WebP files on a server with limited RAM, using Aspose.Imaging’s LoadOptions.BufferSizeHint to cap memory consumption.
 * 3. When a desktop application processes thousands of user‑uploaded WebP assets for a game and must ensure each image is loaded and saved as PNG without exceeding a 100 MB memory budget.
 * 4. When a cloud‑based microservice receives WebP images from a CDN and needs to batch‑convert them to PNG before storing them in Azure Blob Storage, applying a memory‑usage limit to keep the service stable.
 * 5. When a scheduled maintenance script on a Windows file server archives legacy WebP graphics into PNG format and must enforce a memory limit to avoid impacting other shared resources.
 */