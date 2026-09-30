// HOW-TO: Convert Large EPS to PDF/A-1b With Memory Efficient Tiling In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/large.eps";
            string outputPath = "Output/large.pdf";

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
                    PdfDocumentInfo = new PdfDocumentInfo(),
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    },
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
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
 * 1. When a developer needs to transform a high‑resolution EPS artwork into a PDF/A‑1b compliant document without exhausting system memory.
 * 2. When an application must generate archival‑ready PDFs from vector EPS files that are too large to load entirely into RAM.
 * 3. When a printing workflow requires converting EPS logos or diagrams to PDF while preserving exact dimensions and a white background.
 * 4. When a server‑side service processes user‑uploaded EPS files and needs to output PDFs that meet regulatory compliance standards.
 * 5. When a batch job converts a collection of EPS files into PDFs and must handle each file efficiently to avoid out‑of‑memory crashes.
 */
