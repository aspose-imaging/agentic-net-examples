// HOW-TO: How To Convert Multiple WebP Images To PNG With Memory Limit In C# (Aspose.Imaging for .NET)
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
            // Hard‑coded list of WebP files to process
            string[] inputPaths = new[]
            {
                @"c:\temp\image1.webp",
                @"c:\temp\image2.webp"
            };

            // Memory limit for internal buffers (in megabytes)
            const int memoryLimitMb = 50;

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same folder, .png extension)
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set memory limit when loading the image
                var loadOptions = new LoadOptions { BufferSizeHint = memoryLimitMb };

                // Load the WebP image with the specified memory limit
                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    // Save as PNG using default options
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
 * 1. When processing thousands of high‑resolution WebP files on a server with limited RAM, you can set a memory limit while loading each image to prevent out‑of‑memory crashes during batch conversion to PNG.
 * 2. When a desktop application needs to generate PNG thumbnails from user‑uploaded WebP images without exhausting the application's memory pool, applying a memory usage cap ensures smooth performance.
 * 3. When automating image migration for a website that stores assets in WebP format and wants to serve PNG to older browsers, limiting memory usage keeps the bulk conversion job stable.
 * 4. When integrating Aspose.Imaging into a CI/CD pipeline that processes image assets, setting a memory limit helps keep the build agent responsive during large‑scale conversions.
 * 5. When developing a cloud function or microservice that receives WebP images and returns PNG responses, configuring a memory usage limit ensures the service stays within its allocated container memory.
 */
