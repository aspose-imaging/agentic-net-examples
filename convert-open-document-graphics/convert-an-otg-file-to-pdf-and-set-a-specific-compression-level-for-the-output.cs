using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Set rasterization options for OTG conversion
                var otgRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure PDF options with a specific compression level
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // Choose desired compression (e.g., Flate)
                        Compression = PdfImageCompressionOptions.Flate
                    },
                    // Apply the OTG rasterization settings to the PDF conversion
                    VectorRasterizationOptions = otgRasterizationOptions
                };

                // Save the image as PDF using the configured options
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy OTG vector graphics to PDF for client distribution while controlling file size with Flate compression.
 * 2. When an automated document generation service must batch‑process OTG files on a server and produce PDF reports with a specific compression level to meet storage quotas.
 * 3. When a Windows desktop application allows users to export edited OTG images to PDF and must preserve the original page size using rasterization options.
 * 4. When integrating Aspose.Imaging into a C# web API that receives OTG uploads and returns PDF streams, requiring explicit PDF core options to enforce consistent compression across all responses.
 * 5. When a scheduled C# job validates the existence of OTG assets, creates missing output directories, and converts them to PDF with Flate compression to comply with archival standards.
 */