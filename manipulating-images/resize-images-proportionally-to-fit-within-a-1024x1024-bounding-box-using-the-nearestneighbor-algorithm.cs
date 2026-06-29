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
                // Determine scaling factor to fit within 1024x1024 while preserving aspect ratio
                const int maxSize = 1024;
                double widthScale = (double)maxSize / image.Width;
                double heightScale = (double)maxSize / image.Height;
                double scale = Math.Min(widthScale, heightScale);

                // If the image is already within the bounds, keep original size
                if (scale > 1.0) scale = 1.0;

                int newWidth = (int)Math.Round(image.Width * scale);
                int newHeight = (int)Math.Round(image.Height * scale);

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
 * 1. When generating thumbnails for a web gallery where JPEG images must fit inside a 1024 × 1024 bounding box without distortion, a developer can use this code to resize proportionally with the NearestNeighbour algorithm.
 * 2. When preparing high‑resolution product photos for an e‑commerce platform that limits uploads to 1024 × 1024 pixels, the snippet ensures the images are scaled down while preserving aspect ratio and saved back to disk.
 * 3. When converting scanned documents in TIFF or PNG format to a size suitable for email attachments, a C# application can apply this routine to shrink the files to the maximum allowed dimensions.
 * 4. When building a batch‑processing tool that normalizes user‑uploaded avatars to a 1024 × 1024 bounding box before storing them in Azure Blob Storage, the code provides a fast nearest‑neighbor resize using Aspose.Imaging.
 * 5. When creating a desktop utility that automatically resizes large camera RAW exports to a manageable size for machine‑learning preprocessing, the developer can rely on this example to keep the original aspect ratio and output a JPEG file.
 */