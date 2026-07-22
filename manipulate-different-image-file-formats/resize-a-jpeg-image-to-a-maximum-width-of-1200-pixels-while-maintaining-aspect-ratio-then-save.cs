using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

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

            // Load the JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                const int maxWidth = 1200;

                // Determine new dimensions while preserving aspect ratio
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded JPEG photos so that the images never exceed 1200 px in width, preserving the original aspect ratio.
 * 2. When an e‑commerce platform must automatically downsize product photos stored as JPEG files before publishing them to a CDN to reduce bandwidth while keeping the images proportional.
 * 3. When a desktop utility written in C# has to batch‑process high‑resolution JPEG scans, resizing each to a maximum width of 1200 px to fit within email attachment limits.
 * 4. When a content management system integrates Aspose.Imaging to ensure that editorial JPEG images are resized on upload, maintaining aspect ratio to avoid distortion in responsive layouts.
 * 5. When a mobile backend service uses C# to resize incoming JPEG uploads to a standard width of 1200 px, guaranteeing consistent display across devices without stretching the image.
 */