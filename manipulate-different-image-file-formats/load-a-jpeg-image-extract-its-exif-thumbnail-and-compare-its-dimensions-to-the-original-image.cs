using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\thumbnail_output.jpg";

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

            // Load JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                int originalWidth = jpegImage.Width;
                int originalHeight = jpegImage.Height;

                // Access EXIF data and retrieve thumbnail
                JpegExifData jpegExif = jpegImage.ExifData as JpegExifData;
                if (jpegExif?.Thumbnail != null)
                {
                    using (RasterImage thumbnail = jpegExif.Thumbnail)
                    {
                        int thumbWidth = thumbnail.Width;
                        int thumbHeight = thumbnail.Height;

                        Console.WriteLine($"Original dimensions: {originalWidth}x{originalHeight}");
                        Console.WriteLine($"Thumbnail dimensions: {thumbWidth}x{thumbHeight}");

                        // Compare dimensions
                        if (thumbWidth == originalWidth && thumbHeight == originalHeight)
                        {
                            Console.WriteLine("Thumbnail dimensions match the original image.");
                        }
                        else
                        {
                            Console.WriteLine("Thumbnail dimensions differ from the original image.");
                        }

                        // Save thumbnail to output path
                        thumbnail.Save(outputPath);
                    }
                }
                else
                {
                    Console.WriteLine("No EXIF thumbnail found in the image.");
                }
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
 * 1. When building a photo‑gallery web application that must verify the embedded EXIF thumbnail dimensions match the original JPEG before showing a preview.
 * 2. When creating a digital asset management system that validates image metadata by comparing the EXIF thumbnail size to the full‑size image dimensions.
 * 3. When developing a batch‑processing script that flags JPEG files whose EXIF thumbnails are incorrectly scaled, ensuring proper thumbnail generation for mobile devices.
 * 4. When implementing a C# utility that extracts the embedded thumbnail from a JPEG and checks its width and height against the original image to detect corrupted or missing EXIF data.
 * 5. When writing a migration tool that moves images to new storage and needs to confirm the EXIF thumbnail can serve as a fallback preview without additional resizing.
 */