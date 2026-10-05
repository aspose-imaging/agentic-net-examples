// HOW-TO: Convert ODG to JPEG with EXIF Orientation Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.jpg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    KeepMetadata = true
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When a web application needs to display OpenDocument graphics as JPEG thumbnails while keeping the original camera rotation information.
 * 2. When a batch processing tool converts user‑uploaded ODG diagrams to JPEG for email attachments and must retain EXIF orientation for correct viewing on mobile devices.
 * 3. When a digital asset management system imports ODG files and stores them as JPEGs, preserving metadata so downstream editors can read the original orientation.
 * 4. When a reporting service generates JPEG charts from ODG templates and wants the images to appear upright in PDF reports without additional rotation code.
 * 5. When a migration script moves legacy ODG artwork to a JPEG‑based CMS and must keep EXIF orientation to avoid manual image correction.
 */
