// HOW-TO: Resize PNG to Half Width and Save as JPEG in C# (Aspose.Imaging for .NET)
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate new dimensions (half width, maintain aspect ratio)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2; // proportional reduction

                // Resize the image
                image.Resize(newWidth, newHeight);

                // Prepare JPEG save options with desired quality
                var jpegOptions = new JpegOptions
                {
                    Quality = 90 // set quality between 1 and 100
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate smaller JPEG thumbnails from large PNG assets for faster web page loading.
 * 2. When converting high‑resolution PNG logos to lower‑quality JPEGs to reduce file size while keeping the original aspect ratio.
 * 3. When preparing images for email attachments where PNG is not supported and a specific JPEG quality is required.
 * 4. When automating batch processing of product images that must be half the original width for a mobile app.
 * 5. When integrating image optimization into a C# backend that stores user‑uploaded PNGs as compressed JPEGs for storage savings.
 */
