// HOW-TO: Extract JPEG EXIF Thumbnail and Save as Separate Image in C# (Aspose.Imaging for .NET)
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
        string inputPath = "sample.jpg";
        string outputPath = "thumbnail.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Retrieve the EXIF thumbnail
                RasterImage thumbnail = jpegImage.ExifData?.Thumbnail;

                if (thumbnail == null)
                {
                    Console.Error.WriteLine("No EXIF thumbnail found in the image.");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the thumbnail as a separate file
                thumbnail.Save(outputPath);
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
 * 1. When you need to quickly generate a low‑resolution preview of a high‑resolution JPEG without re‑encoding the image.
 * 2. When building a photo‑gallery app that displays thumbnails stored inside the image’s EXIF data.
 * 3. When migrating legacy photos and you want to extract embedded thumbnails for use as separate preview files.
 * 4. When creating a batch process that validates the presence of an EXIF thumbnail and saves it for indexing or cataloging.
 * 5. When optimizing storage by extracting and re‑using the original EXIF thumbnail instead of generating a new thumbnail from scratch.
 */
