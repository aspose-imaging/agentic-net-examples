// HOW-TO: Convert EPS to PDF While Preserving Vector Data in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                using (EpsImage eps = (EpsImage)image)
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        eps.Save(outputPath, pdfOptions);
                    }
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
 * 1. When you need to embed scalable EPS artwork into a PDF report without rasterizing it, this code converts the EPS while keeping the vector information intact.
 * 2. When generating print‑ready PDFs from designer‑provided EPS logos, you can use this snippet to maintain crisp edges at any resolution.
 * 3. When archiving technical drawings originally saved as EPS, the conversion to PDF preserves editability and scalability for future viewers.
 * 4. When building a web service that receives EPS files and returns PDF documents, this code ensures the output remains vector‑based for faster loading.
 * 5. When automating batch processing of EPS illustrations for e‑book publishing, the example lets you convert each file to PDF while retaining vector quality.
 */
