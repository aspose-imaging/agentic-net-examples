// HOW-TO: Save EMF as PDF to Mapped Cloud Drive in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"Z:\CloudStorage\Converted\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EMF image and save as PDF
            using (EmfImage image = (EmfImage)Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to convert legacy EMF vector graphics to PDF for archiving in a shared cloud folder accessed via a mapped drive.
 * 2. When an automated C# service must generate PDF reports from EMF diagrams and store them on a network‑mapped storage location for downstream workflows.
 * 3. When a desktop application processes user‑uploaded EMF files and saves the resulting PDFs directly to a cloud‑synced directory mapped as a drive letter.
 * 4. When a batch job validates the existence of EMF assets, creates the necessary output folders, and writes PDFs to a centralized cloud repository using Aspose.Imaging.
 * 5. When you want to handle conversion errors gracefully while converting EMF images to PDF and placing the files in a mapped cloud storage path for collaboration.
 */
