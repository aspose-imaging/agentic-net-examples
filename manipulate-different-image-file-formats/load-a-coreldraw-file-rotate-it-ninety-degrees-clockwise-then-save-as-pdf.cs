// HOW-TO: Rotate CorelDRAW CDR File 90 Degrees And Save As PDF In C# (Aspose.Imaging for .NET)
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

namespace CorelDrawRotateToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.cdr";
                string outputPath = "output/output.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    image.Save(outputPath, new PdfOptions());
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to automatically re‑orient a CorelDRAW design before generating a printable PDF for a marketing brochure.
 * 2. When a batch process must convert legacy .cdr artwork into PDF while ensuring the page is rotated to match portrait layout requirements.
 * 3. When an application integrates with a document management system and must store rotated CorelDRAW drawings as searchable PDF files.
 * 4. When a web service receives user‑uploaded CDR files and must rotate them clockwise to correct orientation before delivering PDF previews.
 * 5. When a CI/CD pipeline validates design assets by rotating them and exporting to PDF to verify visual consistency across platforms.
 */
