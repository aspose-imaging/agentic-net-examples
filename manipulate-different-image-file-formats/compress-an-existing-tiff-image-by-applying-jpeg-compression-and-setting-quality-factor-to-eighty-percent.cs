// HOW-TO: Compress TIFF to JPEG with 80% Quality Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output/compressed.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 80
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
 * 1. When you need to reduce the file size of high‑resolution TIFF scans for faster web delivery by converting them to JPEG with a specific quality setting.
 * 2. When a document‑management system must store archived images as smaller JPEG files while preserving acceptable visual quality.
 * 3. When generating thumbnails for a photo‑gallery that originally contains TIFF files, and you want to control the compression level programmatically.
 * 4. When integrating a batch‑processing pipeline that converts scanned TIFF invoices to compressed JPEGs before uploading to a cloud storage service.
 * 5. When optimizing images for email attachments by converting large TIFF attachments to JPEG with an 80 % quality factor using C#.
 */
