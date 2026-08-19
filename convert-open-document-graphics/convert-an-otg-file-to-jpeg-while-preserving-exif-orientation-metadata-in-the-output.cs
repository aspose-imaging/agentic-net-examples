// HOW-TO: Convert OTG to JPEG While Preserving EXIF Orientation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.otg");
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
 * 1. When a photographer needs to batch‑convert OTG raw files to JPEG for web publishing while keeping the original EXIF orientation intact.
 * 2. When a digital asset management system imports legacy OTG images and requires JPEG versions that retain metadata for accurate cataloging.
 * 3. When a mobile application processes OTG photos captured on a device and must output JPEGs that display correctly without manual rotation.
 * 4. When an e‑commerce platform receives product images in OTG format and converts them to JPEG for faster page loads while preserving orientation data.
 * 5. When a migration script archives old OTG files to JPEG format for long‑term storage, ensuring the EXIF orientation metadata is not lost.
 */
