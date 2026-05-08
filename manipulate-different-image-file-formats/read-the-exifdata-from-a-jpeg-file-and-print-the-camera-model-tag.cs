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
            // Hardcoded input path
            string inputPath = "C:\\temp\\sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load JPEG image and access EXIF data
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Cast to JpegExifData to access Model property
                var jpegExif = image.ExifData as JpegExifData;
                if (jpegExif != null && !string.IsNullOrEmpty(jpegExif.Model))
                {
                    Console.WriteLine($"Camera model: {jpegExif.Model}");
                }
                else
                {
                    Console.WriteLine("Camera model tag not found.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}