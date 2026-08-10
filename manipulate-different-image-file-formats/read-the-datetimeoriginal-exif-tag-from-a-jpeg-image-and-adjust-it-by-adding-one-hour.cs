// HOW-TO: How to Add One Hour to JPEG EXIF DateTimeOriginal in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Globalization;
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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access EXIF data
                ExifData exif = image.ExifData;
                if (exif != null && !string.IsNullOrEmpty(exif.DateTimeOriginal))
                {
                    // Parse the original DateTime string (format: yyyy:MM:dd HH:mm:ss)
                    if (DateTime.TryParseExact(
                            exif.DateTimeOriginal,
                            "yyyy:MM:dd HH:mm:ss",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime originalDateTime))
                    {
                        // Add one hour
                        DateTime updatedDateTime = originalDateTime.AddHours(1);

                        // Write back in the same format
                        exif.DateTimeOriginal = updatedDateTime.ToString("yyyy:MM:dd HH:mm:ss");
                    }
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When you need to correct the capture time of photos taken in a different time zone by shifting the JPEG DateTimeOriginal EXIF tag forward one hour using Aspose.Imaging in C#.
 * 2. When an application must synchronize image timestamps with a server clock that is one hour ahead, updating the EXIF DateTimeOriginal field of each JPEG file programmatically.
 * 3. When preparing a photo gallery for legal evidence, you may need to adjust the original capture time in the JPEG metadata to reflect daylight‑saving changes before archiving.
 * 4. When automating a batch import of travel photos, you can use this code to add an hour to each image’s EXIF DateTimeOriginal so the chronological order matches the itinerary.
 * 5. When building a C# tool that repairs corrupted or missing EXIF timestamps, adding a one‑hour offset ensures consistency across all JPEG images processed with Aspose.Imaging.
 */
