using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.pdf";

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

            // Load the WebP image
            using (Image webpImage = Image.Load(inputPath))
            {
                // Prepare PDF options and preserve metadata
                var pdfOptions = new PdfOptions
                {
                    KeepMetadata = true,
                    // Transfer EXIF data from the source image if present
                    ExifData = webpImage.Metadata?.ExifData,
                    // Transfer XMP data as well (optional)
                    XmpData = webpImage.Metadata?.XmpData
                };

                // Save as PDF preserving EXIF metadata
                webpImage.Save(outputPath, pdfOptions);
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
 * 1. When a photography website needs to convert user‑uploaded WebP images to PDF portfolios while keeping the original camera EXIF data for attribution and copyright tracking.
 * 2. When a mobile app generates PDF receipts that embed WebP screenshots of a scene and must retain GPS coordinates and timestamp metadata for audit purposes.
 * 3. When a digital asset management system migrates archived WebP files to searchable PDF documents and wants to preserve EXIF tags so assets remain searchable by camera model or capture date.
 * 4. When an e‑commerce platform creates printable product catalogs from WebP product photos and needs to retain XMP and EXIF metadata for compliance with brand guidelines and image provenance.
 * 5. When a legal firm converts WebP evidence images to PDF case files and must maintain the original EXIF metadata to support chain‑of‑custody documentation.
 */