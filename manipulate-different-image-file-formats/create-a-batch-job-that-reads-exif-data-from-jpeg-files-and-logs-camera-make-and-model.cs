// HOW-TO: Read EXIF Camera Make and Model from JPEG Batch in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputImages";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            var jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            foreach (var filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                using (JpegImage image = (JpegImage)Image.Load(filePath))
                {
                    var exif = image.ExifData;
                    if (exif != null)
                    {
                        Console.WriteLine($"{Path.GetFileName(filePath)}: EXIF data present.");
                    }
                    else
                    {
                        Console.WriteLine($"{Path.GetFileName(filePath)}: No EXIF data.");
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

/*
 * Real-World Use Cases:
 * 1. When you need to generate a report of camera models used in a collection of JPEG photos for digital asset management.
 * 2. When you want to verify that uploaded images contain EXIF metadata before publishing them on a website.
 * 3. When you are building a photo‑organizing tool that groups images by camera make for easier browsing.
 * 4. When you must audit image files for compliance by confirming that each JPEG includes manufacturer information.
 * 5. When you are creating a migration script that extracts EXIF details to populate a database of image metadata.
 */
