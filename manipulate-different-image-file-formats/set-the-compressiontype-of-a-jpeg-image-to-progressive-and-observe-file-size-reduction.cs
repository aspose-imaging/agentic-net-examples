using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\sample.progressive.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Set up JPEG save options with progressive compression
                JpegOptions saveOptions = new JpegOptions
                {
                    BitsPerChannel = 8,
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 90 // Adjust quality as needed (1-100)
                };

                // Save the image using the configured options
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to optimize website images for faster page loads by converting high‑resolution BMP files to progressive JPEGs with reduced file size.
 * 2. When an application must generate email‑friendly image attachments that load incrementally, using C# and Aspose.Imaging to save photos as progressive JPEGs.
 * 3. When a mobile app has limited bandwidth and requires on‑the‑fly conversion of user‑uploaded pictures to progressive JPEG format to minimize data usage.
 * 4. When a digital asset management system needs to archive scanned documents as progressive JPEGs to balance quality (90 % quality) with storage savings.
 * 5. When a batch‑processing script processes a folder of BMP images, applying progressive JPEG compression via Aspose.Imaging to prepare them for cloud storage or CDN distribution.
 */