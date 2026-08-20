// HOW-TO: Convert OTG to Progressive JPEG in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.otg";
        string outputPath = "sample_converted.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with progressive compression
                var jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 100 // optional: set desired quality (1-100)
                };

                // Set vector rasterization options for OTG conversion
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                jpegOptions.VectorRasterizationOptions = otgRasterOptions;

                // Save as JPEG
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
 * 1. When a web application needs to display vector‑based OTG graphics as fast‑loading progressive JPEGs for browsers.
 * 2. When an e‑commerce platform must batch‑convert product illustrations stored in OTG format to high‑quality JPEGs with progressive compression to improve page load speed.
 * 3. When a content management system imports OTG files and needs to store them as JPEGs that render progressively on mobile devices.
 * 4. When a reporting tool generates charts in OTG and requires them to be saved as JPEG images with adjustable quality for email attachments.
 * 5. When a migration script moves legacy OTG assets to a JPEG format while preserving vector details through rasterization options.
 */
