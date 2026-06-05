using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputPath = "output.webp";

            // Validate input file existence
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
                // Cache data for better performance
                if (!image.IsCached)
                    image.CacheData();

                // Calculate central 200x200 rectangle
                int cropWidth = 200;
                int cropHeight = 200;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;

                Rectangle rect = new Rectangle(left, top, cropWidth, cropHeight);

                // Crop the image
                image.Crop(rect);

                // Save with default options
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
 * 1. When a developer needs to generate a thumbnail by extracting the central 200 × 200 pixels from a WebP image for use in a responsive web gallery.
 * 2. When an e‑commerce platform must crop product photos to a fixed square size before storing them as WebP files to reduce bandwidth.
 * 3. When a mobile app needs to preprocess user‑uploaded WebP avatars by centering and cropping them to a 200 × 200 region for consistent UI layout.
 * 4. When a content management system automates the creation of preview images by cropping the middle portion of high‑resolution WebP assets.
 * 5. When a digital signage solution prepares WebP graphics by trimming the central area to a 200 × 200 pixel block for display on small screens.
 */