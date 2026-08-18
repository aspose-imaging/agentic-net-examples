// HOW-TO: Resize JPEG to Maximum Width 1200 Pixels While Preserving Aspect Ratio in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_resized.jpg";

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

            // Load the JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Determine new dimensions while preserving aspect ratio
                const int maxWidth = 1200;
                int newWidth = jpegImage.Width;
                int newHeight = jpegImage.Height;

                if (jpegImage.Width > maxWidth)
                {
                    newWidth = maxWidth;
                    newHeight = (int)Math.Round((double)jpegImage.Height * maxWidth / jpegImage.Width);
                }

                // Resize if needed
                if (newWidth != jpegImage.Width || newHeight != jpegImage.Height)
                {
                    jpegImage.Resize(newWidth, newHeight);
                }

                // Save the resized image
                jpegImage.Save(outputPath);
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
 * 1. When you need to generate web‑optimized JPEG thumbnails that never exceed 1200 px in width while keeping the original proportions.
 * 2. When uploading user‑submitted photos to a server and you must downscale large JPEGs to a consistent maximum width before storage.
 * 3. When preparing product images for an e‑commerce site and you want to ensure all JPEGs fit within a 1200 px width constraint without distortion.
 * 4. When creating a batch script that processes a folder of high‑resolution JPEGs, resizing each to a maximum width for faster page load times.
 * 5. When integrating image handling into a C# desktop application that must automatically resize selected JPEG files to a standard width for printing or sharing.
 */
