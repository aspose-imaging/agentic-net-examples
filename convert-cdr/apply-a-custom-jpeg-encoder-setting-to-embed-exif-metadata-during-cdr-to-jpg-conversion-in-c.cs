// HOW-TO: Convert CDR to JPEG With Quality Settings And Add EXIF Date In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    CompressionType = JpegCompressionMode.Baseline
                };
                cdrImage.Save(outputPath, jpegOptions);
            }

            using (JpegImage jpegImage = (JpegImage)Image.Load(outputPath))
            {
                var exif = jpegImage.ExifData;
                if (exif != null)
                {
                    exif.DateTime = "2023:01:01 12:00:00";
                }
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
 * 1. When you need to create JPEG previews of CorelDRAW (CDR) files for a web gallery while setting a specific compression quality and embedding a capture date in the EXIF metadata.
 * 2. When an automated pipeline must convert CDR designs to JPEG images with baseline compression and then add a standardized EXIF DateTime tag for archival consistency.
 * 3. When a digital asset management system requires JPEG outputs from CDR sources that include custom encoder options and consistent EXIF timestamps for searchable metadata.
 * 4. When batch processing dozens of CDR files into JPEGs, you want to apply the same quality level and ensure each resulting image carries the same EXIF date for downstream image analysis.
 * 5. When compliance or reporting demands that converted JPEG files retain a specific EXIF DateTime value, you can embed that metadata during the CDR‑to‑JPEG conversion in C#.
 */
