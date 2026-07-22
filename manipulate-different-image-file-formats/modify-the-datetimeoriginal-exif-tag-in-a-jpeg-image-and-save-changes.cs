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
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.jpg";

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
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access EXIF data
                JpegExifData exif = image.ExifData as JpegExifData;
                if (exif != null)
                {
                    // Set DateTimeOriginal tag (format: "yyyy:MM:dd HH:mm:ss")
                    exif.DateTimeOriginal = "2023:01:01 12:34:56";
                }

                // Save modified image
                image.Save(outputPath);
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
 * 1. When a developer needs to correct the original capture timestamp of a JPEG photo after importing images from a camera with an incorrect date setting, they can use this code to update the DateTimeOriginal EXIF tag.
 * 2. When building a photo management application that organizes images by shoot date, the code can be used to programmatically set the DateTimeOriginal tag for JPEGs lacking proper timestamps.
 * 3. When migrating legacy image archives to a new system and standardizing metadata, developers can employ this snippet to assign a consistent DateTimeOriginal value to each JPEG file.
 * 4. When generating automated reports that require accurate EXIF timestamps for compliance, the code allows developers to overwrite the DateTimeOriginal tag in C# before archiving the JPEGs.
 * 5. When creating a batch processing tool that synchronizes image timestamps with external data sources, this example shows how to modify the DateTimeOriginal EXIF field of JPEG images using Aspose.Imaging for .NET.
 */