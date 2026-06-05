using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputEps";
            string outputDirectory = @"C:\OutputPdf";

            // Get all EPS files in the input directory
            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

            foreach (string inputPath in epsFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set PDF options with uniform compression
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        Compression = PdfImageCompressionOptions.Flate
                    }
                };

                // Load EPS image and save as PDF
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a print shop needs to convert a large collection of vector EPS artwork into PDF files for client delivery while keeping file sizes low.
 * 2. When an e‑learning platform automates the transformation of uploaded EPS diagrams into compressed PDFs for faster web viewing.
 * 3. When a corporate compliance team archives engineering schematics stored as EPS by batch‑converting them to PDF with uniform Flate compression for consistent storage.
 * 4. When a marketing department prepares a batch of EPS logos for inclusion in PDF brochures and wants to ensure all PDFs use the same compression level to meet email attachment limits.
 * 5. When a legal document management system processes incoming EPS contracts, converting each to a searchable PDF with standardized compression to reduce server storage costs.
 */