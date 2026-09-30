// HOW-TO: Convert EPS to PDF/A-1b While Preserving Vector Paths in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.eps");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };
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
 * 1. When you need to embed an EPS illustration into a PDF/A‑1b compliant archive without rasterizing the artwork, this code converts the file while keeping the vector data editable.
 * 2. When a publishing workflow requires batch conversion of EPS logos to PDF for print‑ready documents, you can use this snippet to generate high‑quality PDFs that retain scalability.
 * 3. When a legal or archival system mandates PDF/A‑1b compliance for stored graphics, the example shows how to transform EPS files into compliant PDFs without losing vector fidelity.
 * 4. When integrating Aspose.Imaging into a C# application that processes incoming EPS files from designers, this code enables you to produce PDF outputs that can still be edited in vector editors.
 * 5. When automating document generation where EPS charts must be included in PDFs that pass accessibility checks, the snippet ensures the charts remain vector‑based for crisp rendering at any zoom level.
 */
