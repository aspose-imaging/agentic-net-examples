using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.cmx";
        string outputPath = "output.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the CMX image with default CMX load options
            var loadOptions = new CmxLoadOptions();
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Configure JPEG save options for progressive encoding
                var jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 100 // optional: set desired quality (1-100)
                };

                // Save the image as a progressive JPEG
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
 * 1. When a developer needs to convert legacy CorelDRAW CMX files to web‑friendly JPEG images with progressive loading to improve perceived page speed.
 * 2. When an automated image‑processing pipeline must read CMX artwork and output high‑quality progressive JPEGs for email newsletters that display gradually as they download.
 * 3. When a desktop application imports CMX graphics and saves them as progressive JPEGs to reduce file size while preserving visual fidelity for offline viewing.
 * 4. When a server‑side service receives CMX uploads and needs to generate progressive JPEG thumbnails for faster preview rendering in a content management system.
 * 5. When a migration script updates an archive of CMX assets to progressive JPEG format to ensure compatibility with modern browsers and mobile devices.
 */