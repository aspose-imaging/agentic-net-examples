using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Output\sample.pdf";

        try
        {
            // Verify that the input file exists
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
                // Set up PDF options with compression to reduce file size
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        Compression = PdfImageCompressionOptions.Flate,
                        JpegQuality = 75 // optional lower JPEG quality for further reduction
                    }
                };

                // Save the image as a PDF using the configured options
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
 * 1. When a web application needs to generate downloadable PDFs from PNG screenshots while keeping the file size low for faster user downloads, developers can use this code to apply Flate compression and lower JPEG quality.
 * 2. When an automated reporting system creates PDF invoices from high‑resolution product images and must stay within email attachment size limits, the compression settings in PdfOptions help shrink the PDFs.
 * 3. When a document management workflow converts scanned PNG files to searchable PDFs and wants to reduce storage costs on a cloud server, developers can adjust the PdfCoreOptions to compress the output.
 * 4. When a mobile app generates PDF catalogs from user‑uploaded PNG graphics and must minimize bandwidth usage during sync, the code’s compression configuration ensures compact PDFs.
 * 5. When a batch processing script archives large collections of PNG assets as PDFs for long‑term retention and needs to meet archival size constraints, the Flate compression and JPEG quality settings optimize the resulting PDF size.
 */