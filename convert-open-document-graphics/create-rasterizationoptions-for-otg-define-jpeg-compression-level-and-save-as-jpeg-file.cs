// HOW-TO: Convert OTG to JPEG with Custom Quality Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\temp\sample.otg";
            string outputPath = @"C:\temp\sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure OTG rasterization options
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    // Preserve original size (aspect ratio)
                    PageSize = image.Size
                };

                // Configure JPEG save options with desired compression level
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 80, // Compression level (1-100)
                    VectorRasterizationOptions = otgOptions
                };

                // Save as JPEG using the configured options
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
 * 1. When a web service needs to generate thumbnail JPEGs from OTG vector drawings while preserving the original dimensions.
 * 2. When a desktop application must batch‑convert OTG files to JPEGs with a specific compression level to reduce file size for email attachments.
 * 3. When an automated reporting tool has to embed OTG charts into PDF reports that only accept raster images, requiring JPEG output at a defined quality.
 * 4. When a migration script moves legacy OTG assets to a JPEG‑based content management system and needs consistent image quality across all files.
 * 5. When a mobile app downloads OTG graphics and needs to render them as JPEGs on the device to improve rendering speed and memory usage.
 */
