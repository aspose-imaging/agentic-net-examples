// HOW-TO: Convert CDR to PDF with ClearType Text Rendering in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Drawing.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CdrToPdfConverter
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

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            TextRenderingHint = TextRenderingHint.ClearTypeGridFit
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a PDF from a CorelDRAW (CDR) file and want the embedded text to appear crisp on Windows screens by using ClearType rendering.
 * 2. When automating batch conversion of design assets where preserving text clarity in the resulting PDFs is critical for print‑ready or on‑screen viewing.
 * 3. When integrating Aspose.Imaging into a C# application to convert vector drawings to PDF while controlling rasterization options for sharper typography.
 * 4. When creating a server‑side service that receives CDR files and returns PDFs with optimized text rendering for better readability in PDF viewers.
 * 5. When troubleshooting PDF output quality and need to explicitly set the TextRenderingHint to ClearTypeGridFit to improve anti‑aliasing of text in the converted document.
 */
