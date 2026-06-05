using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.webp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load image data into a byte array
            byte[] imageData = File.ReadAllBytes(inputPath);

            // Create a memory stream from the byte array and load the WebP image
            using (var memoryStream = new MemoryStream(imageData))
            using (var webPImage = new WebPImage(memoryStream))
            {
                // Resize to 1024x768 using bilinear resampling
                webPImage.Resize(1024, 768, ResizeType.BilinearResample);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save with lossless compression
                var saveOptions = new WebPOptions { Lossless = true };
                webPImage.Save(outputPath, saveOptions);
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
 * 1. When a web application needs to accept uploaded WebP images, resize them to a standard 1024 × 768 thumbnail, and store them losslessly using Aspose.Imaging in C#.
 * 2. When a desktop utility processes WebP files loaded from byte arrays, converts them to a uniform resolution, and saves the output with lossless compression to preserve image quality.
 * 3. When an e‑commerce platform generates product preview images from raw WebP data, resizing them for responsive design while ensuring no visual degradation by using lossless WebP options.
 * 4. When a mobile backend service receives WebP image data via an API, resizes the picture to fit device screens and saves it with lossless encoding for later retrieval.
 * 5. When a content management system must transform user‑uploaded WebP assets into a consistent 1024 × 768 size without sacrificing fidelity, leveraging Aspose.Imaging’s WebPImage class and memory streams.
 */