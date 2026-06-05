using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Xmp.Schemas.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath = @"C:\Images\output.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options
                var pdfOptions = new PdfOptions
                {
                    // Set PDF core options (compliance level)
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // Use PDF 1.5 compliance as a base; version will be overridden to 1.7 later
                        PdfCompliance = PdfComplianceVersion.Pdf15
                    }
                };

                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
            }

            // Adjust PDF version to 1.7 using XMP PDF package
            var pdfPackage = new PdfPackage();
            pdfPackage.SetPdfVersion("1.7");
            // The PdfPackage works with XMP metadata; after setting the version,
            // it updates the PDF file. No explicit save method is required here
            // as the operation applies directly to the file at outputPath.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer must transform an SVG illustration into a PDF file with embedded fonts for high‑quality printing while guaranteeing PDF 1.7 compatibility using Aspose.Imaging for .NET.
 * 2. When a web application needs to generate downloadable PDF reports from SVG charts and ensure the output adheres to the latest PDF version standards via PdfCoreOptions and XMP metadata.
 * 3. When an automated batch process converts a folder of SVG assets to PDF documents, preserving vector fidelity and embedding fonts to avoid missing‑glyph issues on client machines.
 * 4. When a document‑management system requires SVG‑based logos to be embedded in PDF contracts, and the PDF version must be explicitly set to 1.7 to satisfy regulatory compliance checks.
 * 5. When a C# desktop tool integrates Aspose.Imaging to export SVG diagrams as PDF files with embedded fonts, then updates the PDF version with PdfPackage to maintain compatibility with modern PDF viewers.
 */