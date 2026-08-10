// HOW-TO: Convert ODG to Progressive JPEG with Maximum Quality in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\temp\sample.odg";
            string outputPath = @"C:\temp\sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options for progressive encoding
                var jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 100 // maximum quality
                };

                // Save as JPEG with the specified options
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
 * 1. When you need to display OpenDocument graphics on a website and want faster loading by serving progressive JPEGs.
 * 2. When an application must batch‑convert ODG drawings to high‑quality JPEGs for email attachments without losing detail.
 * 3. When a content management system stores design files as ODG and requires on‑the‑fly conversion to JPEG for thumbnail previews.
 * 4. When you are building a .NET service that receives ODG uploads and must store them as progressive JPEGs to reduce bandwidth.
 * 5. When you need to integrate Aspose.Imaging into a C# workflow to ensure ODG images are saved as JPEGs with maximum quality for print‑ready PDFs.
 */
