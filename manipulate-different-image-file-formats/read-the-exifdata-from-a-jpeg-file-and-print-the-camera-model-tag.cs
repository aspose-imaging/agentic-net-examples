using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG file path
        string inputPath = "c:\\temp\\sample.jpg";

        // Check that the input file exists; report error and exit if not found
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the JPEG image using Aspose.Imaging
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Retrieve the JPEG-specific EXIF data
            JpegExifData jpegExif = image.ExifData as JpegExifData;

            if (jpegExif != null)
            {
                // Print the camera model tag
                Console.WriteLine($"Camera model: {jpegExif.Model}");
            }
            else
            {
                Console.WriteLine("No JPEG EXIF data available in the image.");
            }
        }
    }
}