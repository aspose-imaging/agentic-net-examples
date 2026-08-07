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
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                JpegImage jpegImage = (JpegImage)image;

                // Access EXIF data
                JpegExifData jpegExif = jpegImage.ExifData as JpegExifData;
                if (jpegExif != null && !string.IsNullOrEmpty(jpegExif.DateTimeOriginal))
                {
                    // Parse the original DateTime string (format: "yyyy:MM:dd HH:mm:ss")
                    if (DateTime.TryParseExact(
                            jpegExif.DateTimeOriginal,
                            "yyyy:MM:dd HH:mm:ss",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,
                            out DateTime originalDate))
                    {
                        // Add one hour
                        DateTime updatedDate = originalDate.AddHours(1);

                        // Write back in the same format
                        jpegExif.DateTimeOriginal = updatedDate.ToString("yyyy:MM:dd HH:mm:ss");
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

                // Save the modified image
                jpegImage.Save(outputPath);
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
 * 1. When a photo‑management application needs to correct the capture time of JPEG images after a daylight‑saving time change, it can read the DateTimeOriginal EXIF tag with Aspose.Imaging for .NET and add one hour.
 * 2. When a digital forensics tool must normalize timestamps across images taken in different time zones, it can load the JPEG, parse the DateTimeOriginal tag, and adjust it by an hour using C# and Aspose.Imaging.
 * 3. When a cloud‑based image‑upload service wants to ensure consistent metadata before storing user photos, it can read the JPEG EXIF DateTimeOriginal value and increment it by one hour to match the server’s clock.
 * 4. When a batch‑processing script processes travel photos and needs to shift all capture times forward by one hour to align with itinerary schedules, it can use Aspose.Imaging to modify the DateTimeOriginal tag in each JPEG file.
 * 5. When a content‑management system displays photo galleries and must display corrected capture times after a recent timezone update, it can load the JPEG image, read the EXIF DateTimeOriginal field, and add one hour using the Aspose.Imaging API.
 */