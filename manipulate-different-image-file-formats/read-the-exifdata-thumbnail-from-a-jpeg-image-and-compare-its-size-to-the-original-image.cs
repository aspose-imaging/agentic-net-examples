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
        string inputPath = "input.jpg";
        string outputPath = "output_thumbnail.jpg";

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

                // Retrieve the thumbnail
                RasterImage thumbnail = exifData.Thumbnail;
                if (thumbnail == null)
                {
                    Console.WriteLine("No thumbnail present in EXIF data.");
                    return;
                }

                // Thumbnail dimensions
                int thumbWidth = thumbnail.Width;
                int thumbHeight = thumbnail.Height;
                Console.WriteLine($"Thumbnail size: {thumbWidth}x{thumbHeight}");

                // Compare areas
                long originalArea = (long)originalWidth * originalHeight;
                long thumbArea = (long)thumbWidth * thumbHeight;
                if (thumbArea > originalArea)
                {
                    Console.WriteLine("Thumbnail is larger than the original image (by area).");
                }
                else if (thumbArea == originalArea)
                {
                    Console.WriteLine("Thumbnail and original image have the same area.");
                }
                else
                {
                    Console.WriteLine("Thumbnail is smaller than the original image (by area).");
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. A photo‑management app extracts the EXIF thumbnail from JPEG files to quickly generate preview grids and checks if the thumbnail dimensions are smaller than the full‑size image before displaying it.
 * 2. An e‑commerce platform validates product images by reading the embedded EXIF thumbnail and ensuring it is not larger than the original to prevent oversized thumbnails from slowing down page loads.
 * 3. A digital asset workflow script reads the JPEG EXIF thumbnail to create a low‑resolution fallback and compares its area to the original image to decide whether to keep or replace the thumbnail.
 * 4. A mobile‑first website uses C# to load JPEG EXIF data, retrieve the thumbnail, and verify that the thumbnail’s pixel count is less than the original before serving it to bandwidth‑constrained devices.
 * 5. An archival tool audits a collection of JPEG photographs, extracts each EXIF thumbnail, and flags any files where the thumbnail size exceeds the original image size, indicating possible corruption or mis‑embedding.
 */