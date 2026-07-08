using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input/input.webp";
        string outputPath = "output/output.webp";

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

            // Load the WebP image
            using (WebPImage image = new WebPImage(inputPath))
            {
                // Define crop size
                int cropWidth = 200;
                int cropHeight = 200;

                // Calculate top-left corner to center the crop rectangle
                int x = (image.Width - cropWidth) / 2;
                int y = (image.Height - cropHeight) / 2;

                // Guard against negative coordinates for very small images
                if (x < 0) x = 0;
                if (y < 0) y = 0;

                // Create the cropping rectangle (Aspose.Imaging.Rectangle)
                Rectangle cropRect = new Rectangle(x, y, cropWidth, cropHeight);

                // Perform the crop
                image.Crop(cropRect);

                // Save the updated image with default options
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
 * 1. When a developer needs to generate a centered 200 × 200 pixel thumbnail from a WebP image for responsive web design using C# and Aspose.Imaging.
 * 2. When a mobile app must extract the most important part of a user‑uploaded WebP photo by cropping a fixed‑size region before uploading to a server.
 * 3. When an e‑commerce platform wants to create uniform product preview images by cropping the central area of high‑resolution WebP files with Aspose.Imaging in a .NET backend.
 * 4. When a content management system automatically prepares profile picture avatars by trimming the middle 200 × 200 pixels of uploaded WebP files using C# image processing.
 * 5. When a digital marketing tool needs to batch‑process WebP banners, cropping each to a standard central square for consistent display across ad networks.
 */