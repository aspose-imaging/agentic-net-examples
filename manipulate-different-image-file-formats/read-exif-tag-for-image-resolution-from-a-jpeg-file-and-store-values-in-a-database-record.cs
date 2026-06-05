using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\resolution.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image img = Image.Load(inputPath))
            {
                var jpegImage = img as JpegImage;
                if (jpegImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a JPEG image.");
                    return;
                }

                var jpegExif = jpegImage.ExifData as Aspose.Imaging.Exif.JpegExifData;
                if (jpegExif == null)
                {
                    Console.Error.WriteLine("No EXIF data found in the JPEG image.");
                    return;
                }

                // Read resolution tags
                var xResolution = jpegExif.XResolution;
                var yResolution = jpegExif.YResolution;

                // Simulate storing in a database by writing to a text file
                string record = $"XResolution: {xResolution}, YResolution: {yResolution}";
                File.WriteAllText(outputPath, record);
                Console.WriteLine("Resolution data stored successfully.");
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
 * 1. When building a digital asset management system that catalogs photos, a developer can use this code to extract the XResolution and YResolution EXIF tags from JPEG files and store them in a database for searchable metadata.
 * 2. When creating a print‑ready workflow that validates image DPI before sending files to a printer, the code can read the JPEG EXIF resolution and record the values in a database to trigger quality checks.
 * 3. When developing a web application that displays image details to users, the code helps retrieve the JPEG resolution tags via Aspose.Imaging and persist them so the UI can show accurate DPI information.
 * 4. When migrating a legacy photo archive to a new content‑management platform, the code can programmatically read each JPEG’s EXIF resolution and save the data in the target system’s database for future reporting.
 * 5. When implementing an automated image‑processing pipeline that selects high‑resolution pictures for machine‑learning training, this code extracts the JPEG resolution tags and logs them in a database to filter suitable images.
 */