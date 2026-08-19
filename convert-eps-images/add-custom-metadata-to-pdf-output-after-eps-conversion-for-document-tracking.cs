// HOW-TO: Convert EPS to PDF/A-1b With Custom Metadata In C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Input\sample.eps";
            string outputPath = @"C:\Output\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Prepare PDF options with compliance and custom metadata
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    },
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Title = "Converted from EPS",
                        Author = "Document Tracking System",
                        Subject = "EPS to PDF conversion",
                        Keywords = "EPS,PDF,Tracking"
                    }
                };

                // Save as PDF with the specified options
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
 * 1. When you need to archive EPS artwork in PDF/A‑1b format while embedding tracking information such as title, author, and keywords.
 * 2. When a document management system requires PDFs generated from EPS files to include specific metadata for searchable indexing and compliance.
 * 3. When converting print‑ready EPS files to PDF for regulatory submission and must ensure the output meets PDF/A‑1b standards.
 * 4. When automating batch conversion of EPS graphics to PDFs and need to add custom document properties for later identification.
 * 5. When integrating Aspose.Imaging into a C# workflow to produce PDFs that can be traced back to the original EPS source via embedded metadata.
 */
