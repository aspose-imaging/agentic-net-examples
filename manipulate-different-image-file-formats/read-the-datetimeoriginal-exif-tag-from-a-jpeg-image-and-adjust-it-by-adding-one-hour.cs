// HOW-TO: Read JPEG DateTimeOriginal EXIF Tag and Add One Hour in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif != null && !string.IsNullOrEmpty(exif.DateTimeOriginal))
                {
                    if (DateTime.TryParseExact(exif.DateTimeOriginal, "yyyy:MM:dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime dt))
                    {
                        dt = dt.AddHours(1);
                        exif.DateTimeOriginal = dt.ToString("yyyy:MM:dd HH:mm:ss");
                    }
                    else
                    {
                        Console.Error.WriteLine("Failed to parse DateTimeOriginal EXIF tag.");
                    }
                }
                else
                {
                    Console.Error.WriteLine("DateTimeOriginal EXIF tag not found.");
                }

                image.Save(outputPath);
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
 * 1. When you need to correct the capture timestamp of JPEG photos taken in a different timezone before uploading them to an online gallery.
 * 2. When you are batch‑processing images to synchronize their EXIF DateTimeOriginal values with a server‑side clock in a C# application.
 * 3. When you want to adjust the original capture time of JPEGs after daylight‑saving time changes to keep metadata accurate.
 * 4. When you need to ensure proper chronological ordering of images for a photo‑journalism workflow by fixing the EXIF timestamp.
 * 5. When you are preparing JPEG images for legal evidence and must reflect the correct capture hour in the EXIF metadata.
 */
