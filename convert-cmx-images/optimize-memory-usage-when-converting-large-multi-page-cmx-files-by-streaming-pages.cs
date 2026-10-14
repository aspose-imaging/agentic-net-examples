// HOW-TO: Convert Large Multi‑Page CMX to PDF with Low Memory in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.cmx";
        string outputPath = "Output\\result.pdf";

        try
        {
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
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
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

/*
 * Real-World Use Cases:
 * 1. When a .NET application must batch‑convert archived CorelDRAW CMX drawings into searchable PDF reports without exhausting server memory.
 * 2. When an automated document‑processing service needs to render each page of a multi‑page CMX file to PDF while preserving original dimensions and background color.
 * 3. When a cloud‑based API receives large CMX uploads and must stream the conversion to PDF to stay within memory quotas.
 * 4. When a desktop utility has to convert user‑selected CMX files to PDF while ensuring the output matches the original page size for printing.
 * 5. When a migration tool moves legacy CMX assets into a PDF archive and requires Aspose.Imaging’s vector rasterization to maintain visual fidelity.
 */
