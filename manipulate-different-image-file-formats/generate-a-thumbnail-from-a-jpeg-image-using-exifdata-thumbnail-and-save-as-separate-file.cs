using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output\\thumbnail.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
            {
                // Get thumbnail from EXIF data
                RasterImage thumbnail = jpeg.ExifData.Thumbnail;
                if (thumbnail == null)
                {
                    Console.Error.WriteLine("No thumbnail found in EXIF data.");
                    return;
                }

                // Save thumbnail as separate file
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
 * 1. When a developer needs to quickly extract the embedded thumbnail from a JPEG's EXIF metadata using Aspose.Imaging for .NET to display a preview in a web gallery without loading the full‑size image.
 * 2. When building a digital asset management system that stores low‑resolution previews, the code can read the JPEG ExifData.Thumbnail via Aspose.Imaging and save it as a separate JPEG file for faster indexing.
 * 3. When creating a photo‑sharing mobile app backend in C#, extracting the EXIF thumbnail with Aspose.Imaging helps generate lightweight preview images for bandwidth‑limited devices.
 * 4. When migrating legacy photo archives, this C# snippet can pull the original EXIF thumbnail from each JPEG using Aspose.Imaging and archive it as an independent file for backup or cataloging.
 * 5. When implementing a batch‑processing tool that validates the presence of EXIF thumbnails in a collection of JPEGs, the code can detect missing thumbnails and log an error using Aspose.Imaging's RasterImage.
 */