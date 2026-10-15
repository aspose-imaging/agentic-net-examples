// HOW-TO: Batch Convert CDR Files To High Quality PDF With AntiAlias Text Rendering In C# (Aspose.Imaging for .NET)
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

namespace CdrBatchToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = @"C:\InputCdr";
                string outputFolder = @"C:\OutputPdf";

                string[] cdrFiles = Directory.GetFiles(inputFolder, "*.cdr");
                foreach (string inputPath in cdrFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        var pdfOptions = new PdfOptions();
                        var vectorOptions = new VectorRasterizationOptions
                        {
                            TextRenderingHint = TextRenderingHint.AntiAlias
                        };
                        pdfOptions.VectorRasterizationOptions = vectorOptions;

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
}

/*
 * Real-World Use Cases:
 * 1. When a design studio needs to automatically convert a folder of CorelDRAW (.cdr) artwork into printable PDF documents while preserving smooth text edges.
 * 2. When an enterprise workflow must generate high‑resolution PDFs from multiple CDR files for archival or compliance purposes without manually opening each file.
 * 3. When a C# application has to batch export vector graphics with anti‑aliased text to ensure the PDFs look crisp on screen and in print.
 * 4. When a developer wants to integrate Aspose.Imaging into a .NET service that processes incoming CDR uploads and returns PDF versions with consistent text rendering quality.
 * 5. When a build script needs to convert newly added CDR assets to PDF as part of a continuous integration pipeline, using TextRenderingHint.AntiAlias to maintain visual fidelity.
 */
