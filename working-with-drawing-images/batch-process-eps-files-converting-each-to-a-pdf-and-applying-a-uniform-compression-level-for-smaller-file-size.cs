using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of EPS files to process
            string[] inputFiles = new string[]
            {
                @"C:\Images\sample1.eps",
                @"C:\Images\sample2.eps"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue; // skip to next file
                }

                // Build the output PDF path (same folder, .pdf extension)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EPS image
                using (EpsImage image = (EpsImage)Image.Load(inputPath))
                {
                    // Configure PDF options with uniform compression
                    var pdfOptions = new PdfOptions
                    {
                        PdfCoreOptions = new PdfCoreOptions
                        {
                            Compression = PdfImageCompressionOptions.Flate
                            // Optional: set compliance if required
                            // PdfCompliance = PdfComplianceVersion.PdfA1b
                        }
                    };

                    // Save the image as PDF
                    image.Save(outputPath, pdfOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When a publishing workflow requires converting a batch of vector EPS artwork into searchable PDF documents while applying Flate compression to reduce file size.
 * 2. When an e‑commerce platform needs to automatically transform product design EPS files into PDF catalogs for customers, ensuring consistent compression across all files.
 * 3. When a legal document management system must archive engineering drawings originally stored as EPS by converting them to PDF/A‑compatible PDFs with uniform compression for long‑term storage.
 * 4. When a desktop application processes user‑uploaded EPS logos and generates compressed PDF previews for quick download without manual intervention.
 * 5. When a CI/CD pipeline for a print‑on‑demand service needs to validate and compress multiple EPS files into PDFs as part of the build step to guarantee size limits before printing.
 */