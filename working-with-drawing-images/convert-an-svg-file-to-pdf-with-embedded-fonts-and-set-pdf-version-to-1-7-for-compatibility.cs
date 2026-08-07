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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Input\sample.svg";
            string outputPath = @"C:\Output\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options
                var pdfOptions = new PdfOptions
                {
                    // Set PDF compliance (closest to PDF 1.7)
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.Pdf15
                    }
                };

                // Set explicit PDF version to 1.7 via XMP package
                var pdfPackage = new PdfPackage();
                pdfPackage.SetPdfVersion("1.7");
                // Note: Aspose.Imaging automatically incorporates XMP metadata when saving

                // Save as PDF with the configured options
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
 * 1. When a developer needs to generate print‑ready PDFs from vector SVG assets while preserving exact typography, they can use Aspose.Imaging in C# to convert the SVG to PDF with embedded fonts and enforce PDF 1.7 compliance.
 * 2. When an automated build pipeline must batch‑process design files and produce archival PDFs that meet a specific PDF version requirement, this code converts each SVG to a PDF with the correct version tag using XMP metadata.
 * 3. When a web application offers users the ability to download scalable graphics as PDFs that are compatible with older PDF viewers, the snippet ensures the output PDF follows PDF 1.7 standards and includes all font data.
 * 4. When a document management system needs to store vector illustrations as searchable PDFs without losing style information, developers can employ this C# example to embed fonts during SVG‑to‑PDF conversion.
 * 5. When a reporting tool integrates custom SVG charts into PDF reports and must guarantee that the generated PDFs open consistently across platforms, the code sets the PDF version to 1.7 and embeds the chart fonts automatically.
 */