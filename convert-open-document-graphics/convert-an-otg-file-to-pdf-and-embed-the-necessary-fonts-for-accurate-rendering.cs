// HOW-TO: Convert OTG File to PDF with Embedded Fonts in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Data\sample.otg";
            string outputPath = @"C:\Data\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for OTG
                OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                {
                    // Preserve original page size
                    PageSize = image.Size
                };

                // Set up PDF save options and attach rasterization options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = otgRasterizationOptions,
                    // Example of setting PDF compliance which can help embed fonts
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };

                // Save the image as PDF
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
 * 1. When you need to generate a PDF from an OTG vector graphic for archival or sharing while preserving exact appearance.
 * 2. When a reporting system must embed fonts to meet PDF/A‑1b compliance for long‑term document preservation.
 * 3. When an application processes engineering diagrams stored as OTG and must deliver them as printable PDFs.
 * 4. When you automate batch conversion of OTG assets to PDFs on a server without manual intervention.
 * 5. When a document workflow requires converting OTG images to PDFs that retain original page size and font fidelity.
 */
