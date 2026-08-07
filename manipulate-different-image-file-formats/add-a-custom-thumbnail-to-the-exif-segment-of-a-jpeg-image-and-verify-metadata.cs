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
            // Hard‑coded paths
            string inputPath = "input.jpg";
            string thumbnailPath = "thumb.jpg";
            string outputPath = "output\\output.jpg";

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
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Load the thumbnail image
                using (RasterImage thumb = (RasterImage)Image.Load(thumbnailPath))
                {
                    // Ensure ExifData container exists
                    if (image.ExifData == null)
                    {
                        image.ExifData = new JpegExifData();
                    }

                    // Cast to JpegExifData to access the Thumbnail property
                    var jpegExif = image.ExifData as JpegExifData;
                    if (jpegExif != null)
                    {
                        // Assign the thumbnail
                        jpegExif.Thumbnail = thumb;
                    }
                }

                // Save the image with the new EXIF thumbnail
                image.Save(outputPath);
            }

            // Verify that the thumbnail was written
            using (JpegImage result = (JpegImage)Image.Load(outputPath))
            {
                var jpegExif = result.ExifData as JpegExifData;
                if (jpegExif != null && jpegExif.Thumbnail != null)
                {
                    Console.WriteLine($"Thumbnail size: {jpegExif.Thumbnail.Width}x{jpegExif.Thumbnail.Height}");
                }
                else
                {
                    Console.WriteLine("Thumbnail not found in saved image.");
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
 * 1. When building a photo‑gallery web app that needs to embed low‑resolution preview images in the EXIF thumbnail field of high‑resolution JPEGs so browsers can display quick thumbnails without loading the full file.
 * 2. When creating a digital asset management system that programmatically adds custom thumbnail images to JPEG files to improve search indexing and preview generation using C# and Aspose.Imaging.
 * 3. When developing a desktop photo‑organizer that must replace missing or corrupted EXIF thumbnails with a user‑selected image and then verify the thumbnail was saved correctly.
 * 4. When implementing an automated workflow that processes batches of product photos, inserting brand‑specific thumbnail graphics into the JPEG EXIF segment before uploading to an e‑commerce platform.
 * 5. When writing a forensic‑analysis tool that needs to inject a reference thumbnail into a JPEG’s EXIF data and later read back the metadata to confirm integrity using JpegImage and JpegExifData classes.
 */