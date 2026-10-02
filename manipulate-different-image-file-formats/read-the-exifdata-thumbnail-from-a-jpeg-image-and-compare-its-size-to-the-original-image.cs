// HOW-TO: Read JPEG EXIF Thumbnail and Compare Its Size to Original Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                int originalWidth = jpegImage.Width;
                int originalHeight = jpegImage.Height;

                var exif = jpegImage.ExifData;
                if (exif == null || exif.Thumbnail == null)
                {
                    Console.WriteLine("No EXIF thumbnail found.");
                    return;
                }

                using (RasterImage thumbImage = (RasterImage)exif.Thumbnail)
                {
                    int thumbWidth = thumbImage.Width;
                    int thumbHeight = thumbImage.Height;

                    Console.WriteLine($"Original size: {originalWidth}x{originalHeight}");
                    Console.WriteLine($"Thumbnail size: {thumbWidth}x{thumbHeight}");
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
 * 1. When you need to verify that the embedded EXIF thumbnail matches the expected dimensions before generating custom previews.
 * 2. When building a photo management tool that decides whether to use the EXIF thumbnail or load the full JPEG based on size comparison.
 * 3. When optimizing storage by checking if the thumbnail is sufficiently small to serve as a low‑resolution placeholder for web galleries.
 * 4. When validating image metadata integrity during batch import to ensure the thumbnail resolution aligns with the original image.
 * 5. When creating a diagnostic script that logs original and thumbnail dimensions to troubleshoot mismatched EXIF data in C# applications.
 */
