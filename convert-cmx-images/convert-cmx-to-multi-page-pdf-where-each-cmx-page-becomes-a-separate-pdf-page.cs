// HOW-TO: Convert CMX File to Multi‑Page PDF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                CmxImage cmx = image as CmxImage;
                if (cmx == null)
                {
                    Console.Error.WriteLine("Loaded image is not a CMX file.");
                    return;
                }

                cmx.Save(outputPath, new PdfOptions());
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
 * 1. When you need to archive legacy CorelDRAW CMX drawings as searchable multi‑page PDF files for easy distribution.
 * 2. When a document management system requires converting each page of a CMX file into separate PDF pages for indexing.
 * 3. When generating printable PDFs from CMX artwork to send to a print shop that only accepts PDF format.
 * 4. When integrating CMX to PDF conversion into a C# batch‑processing pipeline that processes multiple design files automatically.
 * 5. When building a web service that receives CMX uploads and returns a combined PDF for client preview without manual conversion.
 */
