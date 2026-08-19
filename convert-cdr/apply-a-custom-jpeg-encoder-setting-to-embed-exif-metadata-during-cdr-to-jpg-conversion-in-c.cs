// HOW-TO: Convert CDR to JPEG with Custom EXIF Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\output\sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG options with custom EXIF metadata
                JpegOptions jpegOptions = new JpegOptions();

                // Create and populate EXIF data
                JpegExifData exif = new JpegExifData
                {
                    Make = "MyCompany",
                    Model = "MyModel",
                    Artist = "John Doe",
                    Copyright = "© MyCompany 2026",
                    ImageDescription = "Converted from CDR to JPEG with EXIF"
                };
                jpegOptions.ExifData = exif;

                // Optionally set quality (e.g., 90)
                jpegOptions.Quality = 90;

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
 * 1. When you need to batch‑convert CorelDRAW (CDR) files to JPEGs while preserving camera‑like EXIF tags for downstream cataloguing systems.
 * 2. When an e‑commerce platform requires product images generated from CDR artwork with embedded author and copyright information for legal compliance.
 * 3. When a digital asset management workflow must add custom Make, Model, and Artist EXIF fields to JPEGs created from vector designs.
 * 4. When automating image export in a C# application and you want to control JPEG quality and embed descriptive metadata for SEO purposes.
 * 5. When integrating Aspose.Imaging into a Windows service that processes incoming CDR files and stores JPEGs with standardized EXIF data for archival.
 */
