using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hard‑coded input path
        string inputPath = @"C:\Images\sample.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Retrieve EXIF data container
                ExifData exifData = image.ExifData;

                if (exifData == null)
                {
                    Console.WriteLine("No EXIF data found in the image.");
                    return;
                }

                // Header for the console table
                Console.WriteLine("{0,-12} {1}", "Tag ID", "Value");
                Console.WriteLine(new string('-', 50));

                // Iterate over all EXIF properties (includes common, EXIF and GPS tags)
                foreach (var prop in exifData.Properties)
                {
                    // Tag ID as hexadecimal for readability
                    string tagId = $"0x{prop.TagId:X4}";
                    // Convert the value to a string, handling nulls
                    string value = prop.Value?.ToString() ?? "null";

                    Console.WriteLine("{0,-12} {1}", tagId, value);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}