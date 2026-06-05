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
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\source.jpg";
            string outputPath = "C:\\temp\\output.webp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure WebP options: lossy compression with quality 75
                var webpOptions = new WebPOptions
                {
                    Lossless = false,   // lossy compression enables quality setting
                    Quality = 75f       // set desired quality
                };

                // Save the image as WebP with the specified options
                image.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to reduce page load time by converting high‑resolution JPEG photos to smaller WebP files with a controlled quality of 75 using Aspose.Imaging in a C# application.
 * 2. When an e‑commerce platform wants to serve product images in the modern WebP format while preserving transparency support (alpha channel) and maintaining acceptable visual fidelity.
 * 3. When a mobile app backend processes user‑uploaded JPEG avatars and must store them as WebP to save storage space and bandwidth, using C# and Aspose.Imaging’s WebPOptions.
 * 4. When a content management system batch‑converts legacy JPEG assets to WebP with a specific quality setting to meet SEO image‑optimization guidelines.
 * 5. When a developer builds an automated image pipeline that validates the source JPEG, creates the output directory, and saves the image as WebP with lossy compression and a 75 % quality level for consistent rendering across browsers.
 */