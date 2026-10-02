// HOW-TO: Preserve WebP EXIF Metadata When Converting to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage image = (WebPImage)Image.Load(inputPath))
            {
                ExifData exif = image.ExifData;

                PdfOptions options = new PdfOptions
                {
                    ExifData = exif
                };

                image.Save(outputPath, options);
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
 * 1. When a photographer needs to archive WebP photos as PDFs while keeping camera details like exposure and GPS coordinates.
 * 2. When a document management system converts user‑uploaded WebP images to PDF and must retain the original EXIF information for compliance.
 * 3. When a mobile app generates PDF reports from WebP screenshots and wants to embed the source image’s metadata for later analysis.
 * 4. When a legal workflow requires converting WebP evidence files to PDF without losing metadata that proves authenticity.
 * 5. When a batch processing tool migrates a WebP image library to PDF format and needs to preserve EXIF tags for searchable metadata.
 */
