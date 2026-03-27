using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

public class Program
{
    public static void Main()
    {
        // Hardcoded input path
        string inputPath = "Sample.jpg";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Cast EXIF data to JPEG-specific EXIF data
            JpegExifData jpegExif = image.ExifData as JpegExifData;

            if (jpegExif != null)
            {
                // Log camera make and model
                Console.WriteLine($"Camera Make: {jpegExif.Make}");
                Console.WriteLine($"Camera Model: {jpegExif.Model}");
            }
            else
            {
                Console.WriteLine("No JPEG EXIF data found.");
            }
        }
    }
}