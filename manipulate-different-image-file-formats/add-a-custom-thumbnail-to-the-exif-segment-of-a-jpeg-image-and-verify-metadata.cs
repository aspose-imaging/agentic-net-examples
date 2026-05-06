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
            string thumbnailPath = "thumb.jpg";
            string outputPath = "output.jpg";

            // Verify input JPEG exists
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
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = ".";
            Directory.CreateDirectory(outputDir);

            // Load the main JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Load the thumbnail image (any supported raster format)
                using (RasterImage thumbImage = (RasterImage)Image.Load(thumbnailPath))
                {
                    // Access EXIF data container
                    JpegExifData jpegExif = jpegImage.ExifData as JpegExifData;
                    if (jpegExif == null)
                    {
                        // If EXIF segment does not exist, create a new one
                        jpegExif = new JpegExifData();
                        jpegImage.ExifData = jpegExif;
                    }

                    // Assign the thumbnail
                    jpegExif.Thumbnail = thumbImage;

                    // Save the modified JPEG with EXIF thumbnail
                    jpegImage.Save(outputPath);
                }
            }

            // Verify that the thumbnail was written
            using (JpegImage resultImage = (JpegImage)Image.Load(outputPath))
            {
                JpegExifData resultExif = resultImage.ExifData as JpegExifData;
                if (resultExif?.Thumbnail != null)
                {
                    Console.WriteLine("Thumbnail successfully added to EXIF data.");
                    Console.WriteLine($"Thumbnail size: {resultExif.Thumbnail.Width}x{resultExif.Thumbnail.Height}");
                }
                else
                {
                    Console.WriteLine("Thumbnail was not found in the saved image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}