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
            // Hardcoded list of JPEG files to process
            string[] inputPaths = new[]
            {
                @"c:\temp\image1.jpg",
                @"c:\temp\image2.jpg"
            };

            foreach (string inputPath in inputPaths)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the JPEG image
                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    // Cast the generic ExifData to JpegExifData to access Make and Model
                    JpegExifData jpegExif = image.ExifData as JpegExifData;
                    if (jpegExif != null)
                    {
                        Console.WriteLine($"File: {Path.GetFileName(inputPath)}");
                        Console.WriteLine($"Camera Manufacturer (Make): {jpegExif.Make}");
                        Console.WriteLine($"Camera Model: {jpegExif.Model}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"File: {Path.GetFileName(inputPath)} does not contain JPEG EXIF data.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}