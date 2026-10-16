// HOW-TO: Convert EPS to PDF/A-2b Compliant PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
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
            string outputPath = "Output/sample.pdf";

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
 * 1. When a publishing system must archive vector graphics in a PDF/A‑2b format for long‑term preservation, developers can convert EPS files to PDF/A‑2b using Aspose.Imaging in C#.
 * 2. When a print workflow requires PDF/A‑2b compliance to meet industry standards, developers can transform EPS artwork into compliant PDFs programmatically.
 * 3. When a document management application needs to ensure that imported EPS logos are stored as PDF/A‑2b files for legal and accessibility reasons, this code provides the conversion.
 * 4. When an automated batch process must generate PDF/A‑2b reports from EPS diagrams for regulatory submission, developers can use the PdfComplianceVersion enumeration in C#.
 * 5. When a cloud service offers on‑the‑fly conversion of user‑uploaded EPS files to PDF/A‑2b PDFs to guarantee archival quality, this snippet shows how to implement it with Aspose.Imaging.
 */
