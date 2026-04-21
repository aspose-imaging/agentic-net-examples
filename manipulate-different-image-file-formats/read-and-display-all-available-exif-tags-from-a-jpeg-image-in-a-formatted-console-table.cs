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
        string inputPath = @"C:\temp\sample.jpg";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Access EXIF data
            JpegExifData exifData = image.ExifData as JpegExifData;

            // Header for the console table
            Console.WriteLine("{0,-35} {1}", "Tag", "Value");
            Console.WriteLine(new string('-', 70));

            if (exifData != null && exifData.Properties != null)
            {
                // Iterate over all EXIF properties
                foreach (var prop in exifData.Properties)
                {
                    string tagName = prop.Name;
                    string tagValue = prop.Value != null ? prop.Value.ToString() : "null";
                    Console.WriteLine("{0,-35} {1}", tagName, tagValue);
                }
            }
            else
            {
                Console.WriteLine("No EXIF data found in the image.");
            }
        }
    }
}