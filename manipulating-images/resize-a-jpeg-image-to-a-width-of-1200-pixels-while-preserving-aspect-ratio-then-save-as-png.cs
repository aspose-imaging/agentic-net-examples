using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.jpg";
            string outputPath = @"c:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image using the JpegImage constructor
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Calculate new height to preserve aspect ratio
                int newWidth = 1200;
                int newHeight = (int)((double)jpegImage.Height * newWidth / jpegImage.Width);

                // Resize the image
                jpegImage.Resize(newWidth, newHeight);

                // Save as PNG with default options
                jpegImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to create web‑ready images by resizing high‑resolution JPEG photos to a fixed width of 1200 px while preserving aspect ratio and saving them as lossless PNG files for consistent browser rendering.
 * 2. When an e‑commerce platform must generate product thumbnails from original JPEG uploads, ensuring the thumbnails fit a 1200 px width layout and are stored in PNG format to support transparent backgrounds.
 * 3. When a content management system automates the conversion of user‑submitted JPEG images into PNG assets of a standard width for faster page loads and uniform image dimensions across the site.
 * 4. When a digital marketing tool prepares campaign assets by downscaling large JPEG banners to 1200 px wide, maintaining the original proportions, and exporting them as PNG to preserve image quality for email newsletters.
 * 5. When a mobile app backend processes uploaded JPEG photos, resizes them to a 1200 px width to meet device display constraints, and saves them as PNG to enable lossless editing and future format conversions.
 */