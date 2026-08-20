// HOW-TO: Resize Image To Fit Within 1024x1024 Using Nearest Neighbor In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output_resized.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                // Determine scaling factor to fit within 1024x1024 while preserving aspect ratio
                const int maxSize = 1024;
                double widthRatio = (double)maxSize / originalWidth;
                double heightRatio = (double)maxSize / originalHeight;
                double scale = Math.Min(widthRatio, heightRatio);

                // If the image already fits, keep original dimensions
                if (scale > 1.0)
                    scale = 1.0;

                int newWidth = (int)Math.Round(originalWidth * scale);
                int newHeight = (int)Math.Round(originalHeight * scale);

                // Resize using NearestNeighbour algorithm
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Save the resized image
                image.Save(outputPath);
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
 * 1. When you need to generate web‑ready thumbnails that never exceed 1024 px in either dimension while preserving the original aspect ratio.
 * 2. When uploading user photos to a cloud service and you must downscale large JPEGs to a 1024 × 1024 bounding box to reduce bandwidth and storage costs.
 * 3. When preparing product images for an e‑commerce catalog and you want a fast nearest‑neighbor resize to keep sharp edges on pixel art or icons.
 * 4. When processing scanned documents in C# and you need to ensure the resulting PNG fits within a 1024 px limit for PDF embedding without distortion.
 * 5. When building a desktop utility that automatically resizes images in a folder to a maximum size of 1024 px while maintaining aspect ratio using Aspose.Imaging.
 */
