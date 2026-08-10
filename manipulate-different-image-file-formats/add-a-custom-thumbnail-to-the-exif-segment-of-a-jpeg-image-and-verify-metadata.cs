// HOW-TO: Add Custom EXIF Thumbnail to JPEG and Verify Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.jpg";
            string thumbnailPath = "thumb.jpg";
            string outputPath = "output.jpg";

            // Verify input files exist
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the main JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Load the thumbnail image (any supported format)
                using (RasterImage thumb = (RasterImage)Image.Load(thumbnailPath))
                {
                    // Assign the thumbnail to the EXIF data
                    jpegImage.ExifData.Thumbnail = thumb;
                }

                // Verify that the thumbnail was set
                if (jpegImage.ExifData.Thumbnail != null)
                {
                    Console.WriteLine($"Thumbnail set: {jpegImage.ExifData.Thumbnail.Width}x{jpegImage.ExifData.Thumbnail.Height}");
                }
                else
                {
                    Console.WriteLine("Thumbnail not set.");
                }

                // Save the JPEG with updated EXIF data
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
 * 1. When you need to embed a small preview image in a JPEG’s EXIF data so photo‑gallery apps can display a thumbnail without loading the full image.
 * 2. When preparing images for a digital asset management system that requires an EXIF thumbnail for quick browsing and indexing.
 * 3. When creating JPEG files for mobile devices that read the EXIF thumbnail to show a low‑resolution preview before the full‑size picture is downloaded.
 * 4. When adding a custom thumbnail to email attachments so the recipient’s mail client can show a miniature preview of the picture.
 * 5. When you must verify that the thumbnail was correctly written to the JPEG’s EXIF segment to ensure compliance with metadata standards.
 */
