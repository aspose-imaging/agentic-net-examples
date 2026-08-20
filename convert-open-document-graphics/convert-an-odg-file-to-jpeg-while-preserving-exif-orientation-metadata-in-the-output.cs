// HOW-TO: Convert ODG to JPEG with EXIF Orientation Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

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

            using (Image image = Image.Load(inputPath))
            {
                var odgImage = image as OdgImage;
                if (odgImage == null)
                {
                    Console.Error.WriteLine("Failed to load ODG image.");
                    return;
                }

                JpegOptions jpegOptions = new JpegOptions
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
 * 1. When you need to show OpenDocument graphics (ODG) on a website that only supports JPEG images while keeping the original EXIF orientation so the picture displays correctly.
 * 2. When migrating legacy design files to email‑friendly JPEG format and must retain orientation metadata for recipients’ photo viewers.
 * 3. When generating thumbnails for a digital asset manager from ODG drawings and want the thumbnails to respect the original orientation.
 * 4. When integrating Aspose.Imaging into a document management system to automatically convert user‑uploaded ODG files to JPEG while preserving metadata for downstream workflows.
 * 5. When building a C# microservice that prepares design assets for a printing pipeline, converting ODG to JPEG and ensuring the EXIF orientation is maintained for accurate print layout.
 */
