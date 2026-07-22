using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output\\resized.bmp";

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

            // Load BMP image
            using (BmpImage image = (BmpImage)Image.Load(inputPath))
            {
                // Desired maximum dimensions
                int targetWidth = 800;
                int targetHeight = 600;

                // Calculate scaling factor to maintain aspect ratio
                double widthRatio = (double)targetWidth / image.Width;
                double heightRatio = (double)targetHeight / image.Height;
                double scale = Math.Min(widthRatio, heightRatio);

                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                // Resize while preserving aspect ratio
                image.Resize(newWidth, newHeight);

                // Save resized image as BMP
                BmpOptions options = new BmpOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to generate thumbnail previews of user‑uploaded BMP files for a web gallery while preserving the original aspect ratio.
 * 2. When an application must downscale large BMP scans to fit within a printable page size of 800×600 pixels without distortion.
 * 3. When a Windows desktop utility converts high‑resolution BMP screenshots into smaller files for faster email attachment.
 * 4. When a batch‑processing service prepares BMP assets for a mobile game by resizing them to a maximum width and height while keeping their proportions.
 * 5. When a legacy system requires BMP images to be resized to fit into a fixed‑size UI panel, ensuring the image does not appear stretched.
 */