// HOW-TO: Convert CMX to JPEG While Preserving EXIF Orientation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "sample.jpg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions();
                cmxImage.Save(outputPath, jpegOptions);
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
 * 1. When a graphics application needs to export CorelDRAW CMX drawings as JPEG thumbnails for web previews while keeping the original orientation.
 * 2. When an automated batch job processes legacy CMX files and creates JPEGs for a digital asset management system, ensuring the EXIF orientation matches the source.
 * 3. When a mobile app receives CMX files from a server and must display them as JPEGs with correct rotation without extra metadata handling.
 * 4. When a document conversion service integrates Aspose.Imaging to transform CMX artwork into JPEGs for email attachments while preserving orientation metadata.
 * 5. When a migration script moves archived CMX images to a JPEG‑based gallery, requiring the original orientation to remain intact for consistent viewing.
 */
