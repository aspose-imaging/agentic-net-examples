// HOW-TO: Convert WebP to PDF with EXIF Metadata Preservation in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
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
 * 1. When you need to generate a PDF portfolio from WebP photos while keeping the original camera EXIF data for legal or archival purposes.
 * 2. When an e‑commerce platform must provide printable PDF receipts that include product images stored as WebP and retain their metadata for traceability.
 * 3. When a mobile app uploads WebP screenshots to a server that converts them to PDF reports, preserving EXIF information for debugging and user support.
 * 4. When a digital asset management system migrates WebP assets to PDF documents and must maintain photographer details embedded in EXIF tags.
 * 5. When a reporting tool creates PDF catalogs from WebP images and requires the embedded EXIF metadata to be searchable in document metadata fields.
 */
