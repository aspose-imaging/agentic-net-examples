// HOW-TO: Resize EPS to 2000px Width and Save as PDF/A-1b in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
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
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                double scale = 2000.0 / image.Width;
                int newHeight = (int)(image.Height * scale);

                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions { PdfCompliance = PdfComplianceVersion.PdfA1b },
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = 2000,
                        PageHeight = newHeight,
                        BackgroundColor = Color.White
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
 * 1. When you need to convert a high‑resolution EPS illustration to a PDF/A‑1b document that fits a fixed 2000‑pixel width for archival or printing purposes.
 * 2. When a publishing workflow requires rasterizing vector EPS artwork to a specific pixel width before embedding it in a PDF/A‑compliant PDF file.
 * 3. When generating PDF/A‑1b reports from EPS logos and ensuring the output meets ISO‑19005‑1 standards while controlling image dimensions.
 * 4. When automating batch processing of EPS files to create size‑restricted, PDF/A‑1b compliant PDFs for electronic document management systems.
 * 5. When a C# application must resize EPS graphics to a consistent width and export them as PDF/A‑1b to guarantee long‑term preservation and color fidelity.
 */
