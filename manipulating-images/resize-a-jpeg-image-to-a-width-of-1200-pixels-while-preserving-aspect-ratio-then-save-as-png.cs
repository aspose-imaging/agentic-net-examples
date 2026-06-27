using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.jpg";
            string outputPath = "C:\\temp\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image using the provided constructor
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Desired width
                int newWidth = 1200;
                // Compute height to preserve aspect ratio
                int newHeight = (int)Math.Round((double)jpegImage.Height * newWidth / jpegImage.Width);

                // Resize the image (inherited from Image)
                jpegImage.Resize(newWidth, newHeight);

                // Save the result as PNG using the provided Save method and PngOptions
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
 * 1. When a web developer needs to generate a web‑optimized PNG thumbnail from a high‑resolution JPEG for faster page loads while keeping the original aspect ratio.
 * 2. When an e‑commerce platform must convert product photos uploaded as JPEGs to 1200‑pixel‑wide PNGs for consistent display across devices.
 * 3. When a digital asset management system requires batch processing of user‑submitted JPEG images to a standard width and PNG format for archival.
 * 4. When a mobile app backend needs to resize user‑profile JPEG pictures to 1200 px width and store them as lossless PNGs for later editing.
 * 5. When a marketing automation tool prepares email campaign assets by resizing source JPEG banners to a fixed width and saving them as PNG to preserve transparency.
 */