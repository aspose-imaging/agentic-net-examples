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

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Cache data for better performance
                if (!webPImage.IsCached) webPImage.CacheData();

                // Define crop size
                int cropSize = 200;

                // Calculate top-left corner to center the crop area
                int left = (webPImage.Width - cropSize) / 2;
                int top = (webPImage.Height - cropSize) / 2;

                // Adjust if the image is smaller than the crop size
                if (left < 0) left = 0;
                if (top < 0) top = 0;
                int cropWidth = Math.Min(cropSize, webPImage.Width);
                int cropHeight = Math.Min(cropSize, webPImage.Height);

                // Create the crop rectangle
                Rectangle cropRect = new Rectangle(left, top, cropWidth, cropHeight);

                // Perform cropping
                webPImage.Crop(cropRect);

                // Save with default options
                webPImage.Save(outputPath);
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
 * 1. When generating thumbnail previews for a web gallery that stores images in WebP format, a developer can use this code to extract a centered 200 × 200 pixel thumbnail.
 * 2. When preparing profile pictures for a social‑media app that requires a fixed square size, the code can crop the middle of any uploaded WebP image to 200 × 200 pixels before saving.
 * 3. When optimizing product images for an e‑commerce site that uses WebP to reduce bandwidth, the snippet can create a consistent 200 × 200 pixel crop for display in the product carousel.
 * 4. When building a batch‑processing tool that standardizes image dimensions for machine‑learning datasets, this C# example crops the central region of each WebP file to the required size.
 * 5. When implementing a server‑side image‑resizing service in ASP.NET that must return a square WebP preview, the code provides a quick way to crop and save the central 200 × 200 area with default options.
 */