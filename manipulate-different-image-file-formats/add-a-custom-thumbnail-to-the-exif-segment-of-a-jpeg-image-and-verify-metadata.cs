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
            string outputPath = @"C:\Images\output_with_thumb.jpg";

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
                // Load the thumbnail image (any raster image format)
                using (RasterImage thumbImage = (RasterImage)Image.Load(thumbnailPath))
                {
                    // Assign the thumbnail to the EXIF data
                    jpegImage.ExifData.Thumbnail = thumbImage;
                }

                // Save the image with the new EXIF thumbnail
                jpegImage.Save(outputPath);
            }

            // Verify that the thumbnail was written
            using (JpegImage savedImage = (JpegImage)Image.Load(outputPath))
            {
                JpegExifData exif = savedImage.ExifData as JpegExifData;
                if (exif != null && exif.Thumbnail != null)
                {
                    Console.WriteLine("Thumbnail successfully added.");
                    Console.WriteLine($"Thumbnail size: {exif.Thumbnail.Width}x{exif.Thumbnail.Height}");
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