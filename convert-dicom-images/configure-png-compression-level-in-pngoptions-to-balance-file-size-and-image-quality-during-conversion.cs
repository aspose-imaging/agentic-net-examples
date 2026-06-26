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
            string inputPath = @"C:\Images\source.jpg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options with a balanced compression level
                var pngOptions = new PngOptions
                {
                    // CompressionLevel 6 provides a good trade‑off between size and speed
                    CompressionLevel = 6,
                    Progressive = true
                };

                // Save the image as PNG using the configured options
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert high‑resolution JPEG photographs to PNG for web delivery while keeping file size low and preserving visual quality, they can set CompressionLevel 6 in PngOptions.
 * 2. When an e‑commerce platform generates product thumbnails on the fly and wants faster page loads, the code can be used to produce progressive PNGs with balanced compression.
 * 3. When a document management system archives scanned documents as lossless PNGs but must stay within storage quotas, adjusting the PNG compression level helps achieve the required size‑quality trade‑off.
 * 4. When a mobile app syncs user‑generated images to a cloud service and needs to minimize bandwidth usage without noticeable degradation, developers can apply this C# snippet to save images as PNG with moderate compression.
 * 5. When a reporting tool exports charts as PNG images for inclusion in PDF reports and wants consistent rendering across browsers, configuring the PNG options with a specific compression level ensures predictable file size and quality.
 */