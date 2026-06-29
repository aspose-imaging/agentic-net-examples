using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var jpegImage = image as Aspose.Imaging.FileFormats.Jpeg.JpegImage;
                if (jpegImage == null)
                {
                    Console.WriteLine("The file is not a JPEG image.");
                    return;
                }

                var exifData = jpegImage.ExifData;
                if (exifData == null)
                {
                    Console.WriteLine("No EXIF data found.");
                    return;
                }

                var exifType = exifData.GetType();
                var properties = exifType.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

                Console.WriteLine("{0,-30} {1}", "Tag", "Value");
                Console.WriteLine(new string('-', 60));

                foreach (var prop in properties)
                {
                    try
                    {
                        var value = prop.GetValue(exifData);
                        if (value != null)
                        {
                            Console.WriteLine("{0,-30} {1}", prop.Name, value);
                        }
                    }
                    catch
                    {
                        // Ignore any property that throws
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
 * 1. When a developer needs to extract camera settings such as ISO, aperture, and shutter speed from JPEG photos for a photo‑gallery web application, this code reads and displays all EXIF tags in a formatted console table.
 * 2. When building a digital asset management system that validates image metadata before indexing, the snippet helps verify that required EXIF fields are present in JPEG files.
 * 3. When creating a batch‑processing tool that flags images missing GPS coordinates, a developer can use this code to list every EXIF tag and detect the absence of location data.
 * 4. When troubleshooting an image‑processing pipeline that may be stripping metadata, the example provides a quick C# way to compare original and processed JPEG EXIF data.
 * 5. When generating compliance reports that require specific EXIF information such as date‑time stamps in regulated image archives, this code reads and prints the tags for audit purposes.
 */