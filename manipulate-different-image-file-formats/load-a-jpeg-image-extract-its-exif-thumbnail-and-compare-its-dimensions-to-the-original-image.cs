// HOW-TO: Read JPEG EXIF Thumbnail and Compare Its Size to Original Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    var exif = image.ExifData;
                    if (exif == null || exif.Thumbnail == null)
                    {
                        Console.WriteLine("No EXIF thumbnail found.");
                    }
                    else
                    {
                        using (RasterImage thumb = (RasterImage)exif.Thumbnail)
                        {
                            Console.WriteLine($"Original image size: {image.Width}x{image.Height}");
                            Console.WriteLine($"Thumbnail size: {thumb.Width}x{thumb.Height}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to verify that the embedded EXIF thumbnail dimensions match expected values before generating image previews.
 * 2. When building a photo‑management application that displays a low‑resolution preview using the JPEG’s own EXIF thumbnail to improve loading speed.
 * 3. When validating that a camera’s EXIF thumbnail is not corrupted by comparing its width and height to those of the full‑size image.
 * 4. When extracting metadata for compliance reports that require documenting both the thumbnail size and the original image dimensions.
 * 5. When creating a fallback mechanism that uses the EXIF thumbnail if the main JPEG fails to load, you first need to know its size relative to the original.
 */
