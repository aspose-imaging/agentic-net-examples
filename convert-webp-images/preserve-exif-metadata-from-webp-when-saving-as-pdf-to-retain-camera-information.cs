// HOW-TO: Save WebP as PDF while Keeping EXIF Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output.pdf";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the WebP image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF options
                var pdfOptions = new PdfOptions
                {
                    // Preserve original metadata
                    KeepMetadata = true
                };

                // Transfer EXIF data from the WebP image to PDF options, if present
                if (image is WebPImage webPImage && webPImage.ExifData != null)
                {
                    pdfOptions.ExifData = webPImage.ExifData;
                }

                // Save as PDF with the prepared options
                image.Save(outputPath, pdfOptions);
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
 * 1. When an application needs to generate PDF reports from user‑uploaded WebP photos and retain the original camera details for auditing.
 * 2. When a digital asset management system converts WebP images to PDF for archival while preserving EXIF data for future search.
 * 3. When a photo‑sharing website offers downloadable PDFs of WebP images and wants to keep GPS coordinates and timestamps embedded.
 * 4. When a document‑generation service merges WebP screenshots into PDFs and must maintain metadata for compliance tracking.
 * 5. When a mobile app exports captured WebP pictures to PDF and requires the EXIF information to be available for downstream processing.
 */
