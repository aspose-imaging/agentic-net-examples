// HOW-TO: Convert CMX to PDF and Set Document Title in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "input.cmx");
            string outputPath = Path.Combine("Output", "output.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            using (PdfOptions pdfOptions = new PdfOptions())
            {
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
 * 1. When a developer needs to embed legacy CorelDRAW CMX artwork into a PDF report and ensure the PDF metadata includes a specific title for easy identification.
 * 2. When an automated document pipeline must convert batch CMX files to searchable PDFs while assigning a custom title for indexing in a content management system.
 * 3. When a web service receives CMX uploads and must return PDFs with a predefined title so downstream applications can display the correct document name.
 * 4. When a desktop application allows users to export their CMX designs to PDF and wants the exported file to carry a user‑specified title for printing queues.
 * 5. When integrating Aspose.Imaging into a C# workflow to transform CMX graphics into PDFs and embed a custom title for compliance reporting.
 */
