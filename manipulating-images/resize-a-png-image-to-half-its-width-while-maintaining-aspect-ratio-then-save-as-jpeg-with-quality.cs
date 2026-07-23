using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate new dimensions (half the original size, preserving aspect ratio)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Resize the image
                image.Resize(newWidth, newHeight);

                // Prepare JPEG save options with desired quality
                var jpegOptions = new JpegOptions
                {
                    Quality = 85 // Adjust quality as needed (1‑100)
                };

                // Save the resized image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded PNG files by reducing the width to half while keeping the aspect ratio and then storing them as compressed JPEGs for faster page loads.
 * 2. When a batch‑processing tool must convert high‑resolution PNG assets into smaller JPEG images for email newsletters, ensuring the resized width is 50 % of the original and the JPEG quality is set to 85.
 * 3. When a desktop utility has to prepare product photos for an e‑commerce catalog by shrinking PNG images to half size, preserving proportions, and saving them as JPEGs with a specific quality level to meet platform size limits.
 * 4. When a mobile backend service processes incoming PNG screenshots, resizes them to half their width to reduce bandwidth, and outputs JPEG files with controlled compression for storage in a cloud bucket.
 * 5. When an automated report generator needs to embed PNG charts as smaller JPEG images, resizing them to 50 % width while maintaining aspect ratio and applying a quality setting to balance visual fidelity and file size.
 */