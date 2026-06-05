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

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access EXIF data as JpegExifData
                JpegExifData exif = image.ExifData as JpegExifData;
                if (exif != null)
                {
                    // Set the DateTimeOriginal tag (format: "yyyy:MM:dd HH:mm:ss")
                    exif.DateTimeOriginal = "2023:01:01 12:00:00";
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
 * 1. When a photo‑management application needs to correct or set the original capture date of a JPEG file using C# and Aspose.Imaging before indexing the image in a database.
 * 2. When a digital forensics tool must overwrite the DateTimeOriginal EXIF tag of a JPEG to preserve evidence integrity while keeping the image format unchanged.
 * 3. When a batch‑processing script updates the timestamp of product photos to match a launch schedule, using Aspose.Imaging’s JpegExifData in a .NET environment.
 * 4. When a mobile‑to‑desktop sync service synchronizes images and needs to standardize the DateTimeOriginal tag across devices by loading and saving JPEGs with Aspose.Imaging.
 * 5. When a content‑management system automatically adds a watermark and also needs to set the correct original capture date in the EXIF metadata of uploaded JPEGs using C# code.
 */