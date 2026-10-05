// HOW-TO: How To Read Exif Data From A JPEG Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif != null)
                {
                    Console.WriteLine("EXIF data is present.");
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
 * 1. When you need to verify that uploaded JPEG images contain EXIF metadata before further processing in a C# web application.
 * 2. When building a photo‑gallery app that must filter out images lacking camera information using Aspose.Imaging.
 * 3. When creating a server‑side service that validates image files for required EXIF data to enforce compliance with metadata standards.
 * 4. When generating a report that lists which pictures have embedded EXIF data to assist digital asset management.
 * 5. When troubleshooting an image‑conversion pipeline to ensure EXIF data is not stripped during JPEG handling in .NET.
 */
