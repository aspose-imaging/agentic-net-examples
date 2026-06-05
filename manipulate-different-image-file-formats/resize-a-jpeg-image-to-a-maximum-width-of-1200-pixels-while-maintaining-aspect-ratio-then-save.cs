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

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Determine target dimensions while preserving aspect ratio
                const int maxWidth = 1200;
                int targetWidth = jpegImage.Width;
                int targetHeight = jpegImage.Height;

                if (jpegImage.Width > maxWidth)
                {
                    targetWidth = maxWidth;
                    targetHeight = (int)Math.Round((double)jpegImage.Height * maxWidth / jpegImage.Width);
                }

                // Resize only if needed
                if (targetWidth != jpegImage.Width || targetHeight != jpegImage.Height)
                {
                    jpegImage.Resize(targetWidth, targetHeight);
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded JPEG photos while keeping the original aspect ratio and limiting width to 1200 px.
 * 2. When an e‑commerce platform must downsize high‑resolution product images to improve page load speed without distorting the pictures.
 * 3. When a content management system automatically resizes JPEG banners before publishing them to ensure they fit within a 1200‑pixel layout constraint.
 * 4. When a batch‑processing script prepares JPEG assets for email newsletters by scaling them down to a maximum width of 1200 px while preserving quality.
 * 5. When a mobile backend service receives large JPEG uploads and needs to resize them on the server using C# and Aspose.Imaging before storing them in cloud storage.
 */