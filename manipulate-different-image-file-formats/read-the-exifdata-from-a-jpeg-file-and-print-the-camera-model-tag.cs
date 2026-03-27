using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = @"C:\Images\sample.jpg";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Access the EXIF data container
            ExifData exifData = image.ExifData;

            if (exifData != null)
            {
                // Cast to JPEG-specific EXIF data to access the Model property
                JpegExifData jpegExif = exifData as JpegExifData;
                if (jpegExif != null)
                {
                    Console.WriteLine("Camera model: {0}", jpegExif.Model);
                }
                else
                {
                    Console.WriteLine("No JPEG EXIF data available.");
                }
            }
            else
            {
                Console.WriteLine("No EXIF data found in the image.");
            }
        }
    }
}