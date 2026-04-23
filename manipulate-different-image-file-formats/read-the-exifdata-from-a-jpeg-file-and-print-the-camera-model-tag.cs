using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hardcoded input path to the JPEG file.
            string inputPath = @"C:\Images\sample.jpg";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image using Aspose.Imaging.
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access the EXIF data container.
                ExifData exifData = image.ExifData;

                // Ensure EXIF data is present.
                if (exifData != null)
                {
                    // Cast to JpegExifData to access JPEG‑specific tags like Model.
                    JpegExifData jpegExif = exifData as JpegExifData;
                    if (jpegExif != null)
                    {
                        // Print the camera model tag.
                        Console.WriteLine($"Camera model: {jpegExif.Model}");
                    }
                    else
                    {
                        Console.WriteLine("JPEG EXIF data not available.");
                    }
                }
                else
                {
                    Console.WriteLine("No EXIF data found in the image.");
                }
            }
        }
        catch (Exception ex)
        {
            // Output any runtime exception message without crashing.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}