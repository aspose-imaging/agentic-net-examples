using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Sample.eps";
            string outputPath = "Sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image and convert to PDF with custom metadata
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    // Set PDF compliance if needed
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    },
                    // Add custom document metadata
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Title = "Converted from EPS",
                        Author = "MyApp",
                        Subject = "Document tracking",
                        Keywords = $"Creator={image.Creator};Title={image.Title}"
                    }
                };

                // Save the PDF
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
 * 1. When a developer needs to convert legacy EPS artwork into PDF for archival while embedding custom metadata such as title, author, and keywords for document tracking.
 * 2. When an automated C# workflow must generate PDF reports from EPS graphics and ensure PDF/A‑1b compliance for long‑term preservation.
 * 3. When a printing service wants to add creator and source information to PDFs created from EPS files to support downstream content management systems.
 * 4. When a desktop application processes user‑uploaded EPS files and saves them as searchable PDFs with embedded metadata for easy indexing.
 * 5. When a batch job converts multiple EPS files to PDFs and includes custom document info to satisfy regulatory requirements for electronic records.
 */