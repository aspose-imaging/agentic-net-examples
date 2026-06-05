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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = @"C:\Images\output.jpg";
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Try to modify the DateTimeOriginal EXIF tag
                JpegExifData jpegExif = image.ExifData as JpegExifData;
                if (jpegExif != null && !string.IsNullOrEmpty(jpegExif.DateTime))
                {
                    // EXIF date format: "yyyy:MM:dd HH:mm:ss"
                    if (DateTime.TryParseExact(jpegExif.DateTime, "yyyy:MM:dd HH:mm:ss", null,
                        System.Globalization.DateTimeStyles.None, out DateTime dt))
                    {
                        dt = dt.AddHours(1);
                        jpegExif.DateTime = dt.ToString("yyyy:MM:dd HH:mm:ss");
                    }
                }
                else
                {
                    // Fallback to generic ExifData if specific property is unavailable
                    ExifData exif = image.ExifData;
                    if (exif != null && !string.IsNullOrEmpty(exif.DateTimeOriginal))
                    {
                        if (DateTime.TryParseExact(exif.DateTimeOriginal, "yyyy:MM:dd HH:mm:ss", null,
                            System.Globalization.DateTimeStyles.None, out DateTime dt))
                        {
                            dt = dt.AddHours(1);
                            exif.DateTimeOriginal = dt.ToString("yyyy:MM:dd HH:mm:ss");
                        }
                    }
                }

                // Save the modified image
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
 * 1. When a photographer needs to correct JPEG timestamps after discovering the camera’s clock was set one hour behind the local time zone, this code can read the DateTimeOriginal EXIF tag and add the missing hour.
 * 2. When a travel blog aggregates images from multiple countries and must normalize all photo timestamps to a single reference time, developers can use this snippet to adjust each JPEG’s original capture time by one hour.
 * 3. When a legal evidence management system requires accurate time stamps for JPEGs and must compensate for daylight‑saving time errors, the code updates the EXIF DateTimeOriginal field accordingly.
 * 4. When an automated image‑processing pipeline imports batch photos and needs to align them with server logs that are one hour ahead, this C# routine reads and increments the EXIF capture time.
 * 5. When a digital asset management (DAM) tool imports JPEGs whose metadata was recorded in a different time zone, developers can apply this code to shift the DateTimeOriginal tag forward by one hour for consistent cataloging.
 */