// HOW-TO: Extract Each Page from Multi‑Page CDR to Separate PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (var cdr = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Image.Load(inputPath))
            {
                if (cdr is IMultipageImage multipage)
                {
                    int pageCount = multipage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.pdf");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        var pdfOptions = new PdfOptions
                        {
                            MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                        };

                        cdr.Save(outputPath, pdfOptions);
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded file does not support multiple pages.");
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
 * 1. When a designer needs to share individual pages of a CorelDRAW (CDR) document as separate PDF files for client review.
 * 2. When an automated workflow must convert each vector page of a multi‑page CDR archive into standalone PDFs for printing or archiving.
 * 3. When a web application processes uploaded CDR files and must generate per‑page PDF downloads for end users.
 * 4. When a batch script extracts pages from a large CDR catalog to create PDF chapters that can be indexed by search engines.
 * 5. When a document management system stores CDR files and requires separate PDF pages for metadata tagging and version control.
 */
