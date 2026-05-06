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
        string inputPath = @"C:\Images\sample.jpg";
        string thumbnailOutputPath = @"C:\Images\thumbnail.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Retrieve EXIF data
                JpegExifData jpegExifData = jpegImage.ExifData as JpegExifData;

                if (jpegExifData == null)
                {
                    Console.WriteLine("No EXIF data found in the image.");
                    return;
                }

                // Get the thumbnail image from EXIF
                RasterImage thumbnail = jpegExifData.Thumbnail;

                if (thumbnail == null)
                {
                    Console.WriteLine("No EXIF thumbnail present in the image.");
                    return;
                }

                // Compare dimensions
                Console.WriteLine($"Original image size: {jpegImage.Width}x{jpegImage.Height}");
                Console.WriteLine($"EXIF thumbnail size: {thumbnail.Width}x{thumbnail.Height}");

                // Save the thumbnail (output path handling)
                Directory.CreateDirectory(Path.GetDirectoryName(thumbnailOutputPath));
                thumbnail.Save(thumbnailOutputPath);
                Console.WriteLine($"Thumbnail saved to: {thumbnailOutputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}