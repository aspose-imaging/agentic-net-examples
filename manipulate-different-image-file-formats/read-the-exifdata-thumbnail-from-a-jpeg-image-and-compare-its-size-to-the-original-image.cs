using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\sample.jpg";
        string thumbnailOutputPath = @"C:\Images\thumbnail_output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(thumbnailOutputPath));

            // Load JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Original image dimensions
                int originalWidth = jpegImage.Width;
                int originalHeight = jpegImage.Height;
                Console.WriteLine($"Original image size: {originalWidth}x{originalHeight}");

                // Access EXIF thumbnail
                JpegExifData exifData = jpegImage.ExifData as JpegExifData;
                if (exifData?.Thumbnail != null)
                {
                    using (RasterImage thumbnail = exifData.Thumbnail)
                    {
                        int thumbWidth = thumbnail.Width;
                        int thumbHeight = thumbnail.Height;
                        Console.WriteLine($"Thumbnail size: {thumbWidth}x{thumbHeight}");

                        // Compare sizes
                        if (thumbWidth < originalWidth && thumbHeight < originalHeight)
                        {
                            Console.WriteLine("Thumbnail is smaller than the original image.");
                        }
                        else
                        {
                            Console.WriteLine("Thumbnail is not smaller than the original image.");
                        }

                        // Save thumbnail to file
                        thumbnail.Save(thumbnailOutputPath);
                        Console.WriteLine($"Thumbnail saved to: {thumbnailOutputPath}");
                    }
                }
                else
                {
                    Console.WriteLine("No thumbnail found in EXIF data.");
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
 * 1. When building a photo‑gallery web app that needs to verify that embedded EXIF thumbnails in JPEG files are smaller than the full‑resolution image before generating preview tiles.
 * 2. When creating a digital asset management system that validates JPEG EXIF thumbnail dimensions to ensure quick loading of thumbnails on mobile devices.
 * 3. When developing a batch‑processing tool that extracts JPEG EXIF thumbnails and compares their size to the original image to decide whether to replace them with higher‑quality previews.
 * 4. When implementing an automated quality‑control script for a photography workflow that checks that the embedded EXIF thumbnail is indeed smaller than the source JPEG to avoid redundant storage.
 * 5. When writing a C# utility using Aspose.Imaging to read JPEG EXIF data and confirm that the thumbnail dimensions meet the requirements of a third‑party image‑sharing API.
 */