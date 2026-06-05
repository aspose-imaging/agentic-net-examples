using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure JPEG save options with quality set to 95%
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 95
            };

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as JPEG using the configured options
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to convert user‑uploaded PNG graphics to high‑quality JPEG files for faster page loading.
 * 2. When a batch processing tool must generate JPEG thumbnails from PNG assets while preserving visual fidelity with a 95 % quality setting.
 * 3. When an e‑commerce platform wants to store product images as JPEGs to reduce storage costs but still retain near‑original quality.
 * 4. When a desktop utility automates the migration of legacy PNG files to JPEG format for compatibility with older photo‑editing software.
 * 5. When a reporting service exports charts created in PNG format to JPEG for inclusion in PDF documents that require a specific compression level.
 */