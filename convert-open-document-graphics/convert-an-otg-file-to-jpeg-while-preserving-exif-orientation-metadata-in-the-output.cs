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
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/sample.jpg";

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
 * 1. When a developer needs to batch‑convert proprietary OTG graphics from a CAD system into standard JPEG files for web preview while keeping the original EXIF orientation so images display correctly in browsers.
 * 2. When an image‑processing pipeline must ingest OTG files from a legacy archive and output JPEGs for mobile apps, preserving metadata to maintain proper rotation on devices.
 * 3. When a content‑management system imports user‑uploaded OTG assets and stores them as JPEG thumbnails, requiring the orientation metadata to be retained for accurate thumbnail rendering.
 * 4. When a digital‑asset‑management tool automates conversion of OTG product photos to JPEG for e‑commerce catalogs, ensuring the EXIF orientation flag is kept so product images appear upright.
 * 5. When a photo‑editing application offers an “Export as JPEG” feature for OTG files and needs to preserve EXIF orientation so downstream editors and viewers respect the original image rotation.
 */