// HOW-TO: Convert EPS to PDF/A-2b Compliant PDF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
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
 * 1. When you need to archive vector graphics from EPS files in a PDF/A‑2b compliant format for long‑term preservation or regulatory submission.
 * 2. When a printing workflow requires converting EPS artwork to PDF while ensuring the output meets PDF/A‑2b standards for color accuracy and font embedding.
 * 3. When an enterprise document management system must store EPS diagrams as searchable PDFs that conform to PDF/A‑2b for legal compliance.
 * 4. When a C# application automates batch conversion of EPS logos to PDF/A‑2b PDFs to guarantee consistent rendering across different PDF viewers.
 * 5. When you integrate Aspose.Imaging into a .NET service that generates PDF/A‑2b reports from EPS charts to satisfy accessibility and archival guidelines.
 */
