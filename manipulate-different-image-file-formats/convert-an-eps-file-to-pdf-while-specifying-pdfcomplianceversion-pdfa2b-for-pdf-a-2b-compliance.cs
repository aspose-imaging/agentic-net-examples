// HOW-TO: Convert EPS to PDF with PDF/A‑2b Compliance in C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a developer needs to generate archival‑ready PDF/A‑2b documents from vector EPS artwork for long‑term storage.
 * 2. When an application must batch‑process EPS logos and embed them into PDF reports that must meet PDF/A‑2b standards.
 * 3. When a print workflow requires converting EPS files to PDF while ensuring the output complies with PDF/A‑2b for regulatory submission.
 * 4. When a document management system imports EPS diagrams and needs to store them as PDF/A‑2b files for consistent viewing across platforms.
 * 5. When a C# service creates PDF/A‑2b compliant PDFs from EPS templates for electronic invoicing or legal documents.
 */
