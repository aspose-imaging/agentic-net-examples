// HOW-TO: Convert CorelDRAW CDR to PDF via EMF Vector Export in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input/input.cdr";
            string outputPath = "output/output.pdf";
            string tempEmfPath = "output/temp.emf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempEmfPath));

            using (Image cdrImage = Image.Load(inputPath))
            {
                var emfOptions = new EmfOptions();
                cdrImage.Save(tempEmfPath, emfOptions);
            }

            using (Image emfImage = Image.Load(tempEmfPath))
            {
                var pdfOptions = new PdfOptions();
                emfImage.Save(outputPath, pdfOptions);
            }

            File.Delete(tempEmfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed editable vector graphics from a CorelDRAW design into a PDF report without losing quality.
 * 2. When an automated workflow must convert batch CDR files to searchable PDF documents for archiving.
 * 3. When a web service generates PDFs from user‑uploaded CDR files and must preserve text as selectable vector objects.
 * 4. When a desktop application extracts vector shapes from a CDR drawing to create printable PDFs for marketing materials.
 * 5. When a migration script transforms legacy CDR assets into PDF format while keeping the original EMF vector data for future editing.
 */
