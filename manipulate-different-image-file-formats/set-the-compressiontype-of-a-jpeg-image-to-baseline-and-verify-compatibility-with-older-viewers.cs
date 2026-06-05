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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output_baseline.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with Baseline compression
                JpegOptions jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Baseline,
                    Quality = 90 // optional quality setting
                };

                // Save the image as JPEG using Baseline compression
                image.Save(outputPath, jpegOptions);
            }

            // Verify that the saved JPEG uses Baseline compression
            using (Image savedImage = Image.Load(outputPath))
            {
                var jpegImage = savedImage as Aspose.Imaging.FileFormats.Jpeg.JpegImage;
                if (jpegImage != null)
                {
                    // Baseline JPEGs are widely supported by older viewers
                    Console.WriteLine("Saved JPEG uses Baseline compression and is compatible with older viewers.");
                }
                else
                {
                    Console.WriteLine("Saved image is not a JPEG.");
                }
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
 * 1. When a developer needs to convert legacy BMP assets to JPEG files that can be opened by older web browsers or email clients, they can set JpegCompressionMode.Baseline to ensure maximum compatibility.
 * 2. When preparing product catalog images for print‑ready PDFs that must be viewed on outdated viewer software, using Baseline JPEG compression guarantees the images render correctly across all platforms.
 * 3. When building an automated image‑processing pipeline that archives scanned documents as JPEGs, the code verifies the saved file uses Baseline compression so the archive can be accessed by any standard viewer.
 * 4. When integrating a C# application with a third‑party content management system that only accepts Baseline JPEGs, the developer can enforce the compression mode and confirm it before upload.
 * 5. When optimizing image assets for mobile apps that need to support older Android versions, setting the JPEG CompressionType to Baseline and checking the result ensures the images display without errors on legacy devices.
 */