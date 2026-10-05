// HOW-TO: Add Custom EXIF Thumbnail to JPEG and Verify with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string thumbnailPath = "thumb.jpg";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif != null)
                {
                    using (RasterImage thumbImg = (RasterImage)Image.Load(thumbnailPath))
                    {
                        exif.Thumbnail = thumbImg;
                        image.Save(outputPath);
                    }
                }
                else
                {
                    image.Save(outputPath);
                }
            }

            using (JpegImage savedImage = (JpegImage)Image.Load(outputPath))
            {
                var savedExif = savedImage.ExifData;
                if (savedExif != null && savedExif.Thumbnail != null)
                {
                    Console.WriteLine("Thumbnail added successfully.");
                }
                else
                {
                    Console.WriteLine("Thumbnail not found.");
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
 * 1. When a developer needs to embed a small preview image into a JPEG’s EXIF data so that photo‑gallery applications display a custom thumbnail.
 * 2. When building a digital asset management system that must store and later retrieve EXIF thumbnails for quick image browsing.
 * 3. When creating a batch‑processing tool that adds a company logo as a thumbnail to product photos before uploading them to an e‑commerce platform.
 * 4. When validating that an image processing pipeline correctly wrote the thumbnail by loading the saved JPEG and checking the EXIF thumbnail property.
 * 5. When ensuring compliance with camera‑software requirements that expect a JPEG to contain a non‑empty EXIF thumbnail for proper rendering on mobile devices.
 */
