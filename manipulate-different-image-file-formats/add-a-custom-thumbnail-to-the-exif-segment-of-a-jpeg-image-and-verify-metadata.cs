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

            // Load the original JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Load the thumbnail image (any supported format)
                using (RasterImage thumbImg = (RasterImage)Image.Load(thumbnailPath))
                {
                    // Assign the thumbnail to the EXIF data
                    jpegImage.ExifData.Thumbnail = thumbImg;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the JPEG with the new EXIF thumbnail
                jpegImage.Save(outputPath);
            }

            // Verify that the thumbnail was written
            using (JpegImage resultImage = (JpegImage)Image.Load(outputPath))
            {
                RasterImage thumb = resultImage.ExifData.Thumbnail;
                if (thumb != null)
                {
                    Console.WriteLine($"Thumbnail size: {thumb.Width}x{thumb.Height}");
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
 * 1. When a developer needs to embed a custom thumbnail into a JPEG's EXIF segment so that gallery applications can display a quick preview without loading the full image.
 * 2. When a developer wants to replace an existing EXIF thumbnail with a higher‑resolution or branded thumbnail generated from another image format using Aspose.Imaging in a C# workflow.
 * 3. When a developer must ensure that a JPEG file shipped with a product contains a specific thumbnail for compliance with digital asset management standards and wants to verify the thumbnail size after saving.
 * 4. When a developer is building an automated pipeline that reads a source JPEG, adds a generated thumbnail from a separate file, and saves the result to a designated output folder while handling missing files gracefully.
 * 5. When a developer needs to programmatically read back the EXIF thumbnail from a saved JPEG to confirm that the thumbnail was correctly written, using Aspose.Imaging's RasterImage and JpegImage classes in .NET.
 */