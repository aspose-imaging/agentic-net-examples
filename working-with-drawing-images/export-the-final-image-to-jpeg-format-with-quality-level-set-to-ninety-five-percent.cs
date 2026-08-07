using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.jpg";

        try
        {
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

                // Save the image as JPEG using the configured options
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
 * 1. When a developer needs to convert legacy BMP assets to web‑friendly JPEG files while preserving high visual quality for an e‑commerce product catalog.
 * 2. When an automated batch‑processing service must generate thumbnail previews from scanned documents and store them as 95 % quality JPEGs to balance file size and clarity.
 * 3. When a Windows desktop application exports user‑edited screenshots to JPEG for email attachment, ensuring the output meets typical email size limits without noticeable degradation.
 * 4. When a server‑side image pipeline resizes and saves uploaded photos as JPEG with a fixed 95 % quality setting before storing them in a cloud storage bucket.
 * 5. When a reporting tool converts chart images generated in BMP format to JPEG for inclusion in PDF reports, using Aspose.Imaging to control the compression level.
 */