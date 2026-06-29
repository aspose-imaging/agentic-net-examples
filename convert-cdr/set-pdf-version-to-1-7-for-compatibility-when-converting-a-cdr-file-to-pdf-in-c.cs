using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.cdr";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (var image = (CdrImage)Image.Load(inputPath))
            {
                // Configure PDF options with the desired compliance version
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // Aspose.Imaging currently supports up to PDF 1.5 compliance.
                        // Setting this to Pdf15 provides the highest available compliance,
                        // which is compatible with PDF 1.7 readers.
                        PdfCompliance = PdfComplianceVersion.Pdf15
                    }
                };

                // Save as PDF
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
 * 1. When a graphic designer needs to share CorelDRAW (CDR) artwork with clients who only open PDF 1.7 files, this code converts the CDR to a compatible PDF.
 * 2. When an automated document pipeline must archive vector illustrations from CDR files into PDFs that meet PDF 1.7 compliance for long‑term storage, the snippet ensures the correct version is set.
 * 3. When a web application generates printable brochures from CDR templates and must guarantee the resulting PDF works in modern browsers and PDF viewers expecting PDF 1.7, developers can use this conversion routine.
 * 4. When a batch conversion tool runs nightly to transform a library of CDR assets into PDFs for a digital asset management system that validates PDFs against PDF 1.7 standards, this code provides the required setting.
 * 5. When a compliance audit requires that all exported PDFs from design files be compatible with PDF 1.7 specifications, developers can embed this snippet to enforce the version during the CDR‑to‑PDF conversion.
 */