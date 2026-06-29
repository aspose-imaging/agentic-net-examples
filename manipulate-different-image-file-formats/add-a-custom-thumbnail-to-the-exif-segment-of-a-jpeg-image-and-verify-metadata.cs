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
            // Hardcoded paths
            string inputPath = @"C:\Images\input.jpg";
            string thumbnailPath = @"C:\Images\thumb.jpg";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input image exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Verify thumbnail image exists
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
                // Load the thumbnail image (any raster image format)
                using (RasterImage thumbImage = (RasterImage)Image.Load(thumbnailPath))
                {
                    // Assign the thumbnail to the EXIF data
                    if (jpegImage.ExifData == null)
                    {
                        // If ExifData is null, create a new instance
                        jpegImage.ExifData = new JpegExifData();
                    }

                    // Cast to JpegExifData to access Thumbnail property
                    JpegExifData jpegExif = jpegImage.ExifData as JpegExifData;
                    if (jpegExif != null)
                    {
                        jpegExif.Thumbnail = thumbImage;
                    }
                }

                // Save the modified image
                jpegImage.Save(outputPath);
            }

            // Verify that the thumbnail was added
            using (JpegImage resultImage = (JpegImage)Image.Load(outputPath))
            {
                JpegExifData resultExif = resultImage.ExifData as JpegExifData;
                if (resultExif?.Thumbnail != null)
                {
                    Console.WriteLine($"Thumbnail added. Size: {resultExif.Thumbnail.Width}x{resultExif.Thumbnail.Height}");
                }
                else
                {
                    Console.WriteLine("Thumbnail not found in EXIF data.");
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
 * 1. When a developer needs to embed a preview image into the EXIF thumbnail of a JPEG for faster loading in photo gallery apps using C# and Aspose.Imaging.
 * 2. When a digital asset management system must store a custom low‑resolution thumbnail inside each JPEG’s EXIF segment to enable quick browsing on mobile devices.
 * 3. When an e‑commerce platform wants to attach a brand‑specific thumbnail to product photos so that search engines can display a consistent preview in image search results.
 * 4. When a photo‑editing tool requires programmatic verification that the updated EXIF metadata, including the new thumbnail, is correctly saved after processing images in .NET.
 * 5. When a batch‑processing script needs to replace missing or corrupted EXIF thumbnails in a large collection of JPEG files with a standard placeholder image using Aspose.Imaging for .NET.
 */