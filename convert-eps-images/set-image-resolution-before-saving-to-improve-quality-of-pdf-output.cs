// HOW-TO: Set Image Resolution When Converting JPEG to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
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
 * 1. When you need to generate a high‑DPI PDF from a JPEG for professional printing, you set the resolution before saving.
 * 2. When creating PDF reports that embed scanned photos, adjusting the image resolution ensures the PDF meets archival quality standards.
 * 3. When converting user‑uploaded images to PDFs in a web application, specifying 300 dpi prevents blurry output on high‑resolution displays.
 * 4. When automating batch conversion of product images to PDFs for an e‑catalog, setting the resolution guarantees consistent visual fidelity.
 * 5. When integrating Aspose.Imaging into a document workflow that requires PDFs to pass quality checks, you configure the resolution to meet the required DPI threshold.
 */
