// HOW-TO: Convert EPS to PDF with PDF/A-2b Compliance in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and convert to PDF
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var options = new PdfOptions();
                image.Save(outputPath, options);
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
 * 1. When a publishing workflow requires converting vector EPS artwork to PDF files that meet PDF/A‑2b archival standards using C#.
 * 2. When an automated document processing system must generate PDF/A‑2b compliant PDFs from EPS logos for long‑term storage.
 * 3. When a print‑ready pipeline needs to ensure EPS designs are transformed into PDF/A‑2b PDFs to satisfy regulatory compliance before printing.
 * 4. When a cloud service needs to batch‑convert user‑uploaded EPS files to PDF/A‑2b PDFs for legal document submission.
 * 5. When a .NET application integrates Aspose.Imaging to create searchable, standards‑compliant PDFs from EPS diagrams for archival databases.
 */
