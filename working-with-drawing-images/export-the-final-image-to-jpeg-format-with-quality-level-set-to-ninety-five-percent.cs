using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\sample_converted.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with quality 95%
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = 95
                };

                // Save the image as JPEG
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert legacy BMP files to web‑friendly JPEGs with high visual quality for faster page loads.
 * 2. When an application must generate thumbnails from high‑resolution scans and store them as 95% quality JPEGs to balance size and clarity.
 * 3. When a batch‑processing tool has to archive scanned documents by saving them in JPEG format with a specific quality setting to meet storage policies.
 * 4. When a photo‑editing workflow requires exporting edited images from Aspose.Imaging to JPEG with a 95% quality level for client delivery.
 * 5. When a server‑side service processes user‑uploaded BMP images and needs to save them as JPEGs with controlled compression for consistent display across browsers.
 */