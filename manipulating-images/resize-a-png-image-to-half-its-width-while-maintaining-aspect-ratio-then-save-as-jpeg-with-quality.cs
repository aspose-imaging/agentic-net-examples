using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.jpg";

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
                // Compute new dimensions: half the width, maintain aspect ratio
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Resize the image
                image.Resize(newWidth, newHeight);

                // Set JPEG save options with desired quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 80 // Quality range: 1-100
                };

                // Save the resized image as JPEG
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded PNG files by halving their width while preserving aspect ratio and then store them as compressed JPEGs for faster page loads.
 * 2. When an e‑commerce platform must convert high‑resolution product PNG images to smaller JPEG files with a specific quality setting to reduce bandwidth without distorting the original proportions.
 * 3. When a desktop utility processes a batch of PNG screenshots, resizing each to half its original width and saving them as JPEGs to fit within email attachment size limits.
 * 4. When a mobile app backend receives PNG icons, needs to downscale them to half width to match device screen constraints and save them as JPEG with 80 % quality for optimal storage.
 * 5. When a content management system automates the preparation of PNG graphics for print‑to‑web conversion, resizing them while maintaining aspect ratio and outputting JPEGs with controlled compression.
 */