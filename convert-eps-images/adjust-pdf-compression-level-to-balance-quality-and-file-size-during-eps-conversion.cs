// HOW-TO: Convert EPS to PDF with Balanced Compression Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.eps";
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
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                    // Compression level adjustment is not directly supported; using default settings.
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
 * 1. When a developer needs to convert vector EPS artwork to PDF for client delivery while keeping file size reasonable.
 * 2. When generating printable PDFs from EPS logos for marketing materials and wants to preserve visual fidelity without excessive file weight.
 * 3. When building an automated pipeline that ingests EPS files and outputs PDF documents for archival, requiring a balance between quality and storage costs.
 * 4. When integrating Aspose.Imaging into a web service that serves PDF previews of EPS designs and must limit bandwidth usage.
 * 5. When creating batch conversion tools that transform multiple EPS files to PDF and need default compression to simplify code while still achieving acceptable image quality.
 */
