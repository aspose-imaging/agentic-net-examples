// HOW-TO: Extract JPEG EXIF Thumbnail and Compare Its Size to Original in C# (Aspose.Imaging for .NET)
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
        string outputPath = @"C:\Images\thumbnail.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Original image dimensions
                int originalWidth = jpegImage.Width;
                int originalHeight = jpegImage.Height;
                Console.WriteLine($"Original image size: {originalWidth}x{originalHeight}");

                // Access EXIF data
                JpegExifData exifData = jpegImage.ExifData as JpegExifData;
                if (exifData == null)
                {
                    Console.WriteLine("No EXIF data found.");
                    return;
                }

                // Extract thumbnail
                RasterImage thumbnail = exifData.Thumbnail;
                if (thumbnail == null)
                {
                    Console.WriteLine("No EXIF thumbnail present.");
                    return;
                }

                // Thumbnail dimensions
                int thumbWidth = thumbnail.Width;
                int thumbHeight = thumbnail.Height;
                Console.WriteLine($"Thumbnail size: {thumbWidth}x{thumbHeight}");

                // Compare dimensions
                if (thumbWidth == originalWidth && thumbHeight == originalHeight)
                {
                    Console.WriteLine("Thumbnail dimensions match the original image.");
                }
                else
                {
                    Console.WriteLine("Thumbnail dimensions differ from the original image.");
                }

                // Save the thumbnail to a file
                thumbnail.Save(outputPath);
                Console.WriteLine($"Thumbnail saved to: {outputPath}");
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
 * 1. When you need to verify that the embedded EXIF thumbnail of a JPEG matches the actual image size before generating thumbnails for a web gallery.
 * 2. When building a photo‑import tool that extracts and saves the EXIF thumbnail from user‑uploaded JPEGs using Aspose.Imaging in C#.
 * 3. When performing quality checks on a batch of JPEG files to ensure their EXIF metadata contains a correctly sized preview image.
 * 4. When creating a diagnostic utility that reads JPEG EXIF data to compare thumbnail dimensions with the original for debugging camera firmware issues.
 * 5. When developing an automated workflow that extracts JPEG EXIF thumbnails and logs size discrepancies for image‑processing pipelines.
 */
