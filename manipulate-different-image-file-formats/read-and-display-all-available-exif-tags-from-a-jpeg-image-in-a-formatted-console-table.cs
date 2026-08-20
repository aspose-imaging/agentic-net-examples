// HOW-TO: Read All EXIF Tags From a JPEG Image In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exifData = image.ExifData;
                Console.WriteLine("EXIF Tags");
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("{0}", "Value");
                Console.WriteLine(new string('-', 50));

                if (exifData != null)
                {
                    var jpegExif = exifData as Aspose.Imaging.Exif.JpegExifData;
                    if (jpegExif != null && jpegExif.Properties != null)
                    {
                        foreach (var prop in jpegExif.Properties)
                        {
                            Console.WriteLine("{0}", prop.Value);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No EXIF properties available.");
                    }
                }
                else
                {
                    Console.WriteLine("No EXIF data found.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display camera settings and location data embedded in a JPEG for a photo‑management tool.
 * 2. When building a diagnostic utility that verifies whether uploaded images contain required EXIF metadata before processing.
 * 3. When creating a batch script that logs image metadata to audit compliance with digital asset standards.
 * 4. When developing a desktop application that shows users the original capture details of their pictures in a formatted console view.
 * 5. When extracting EXIF values to populate a database for searchable image catalogs using Aspose.Imaging in C#.
 */
