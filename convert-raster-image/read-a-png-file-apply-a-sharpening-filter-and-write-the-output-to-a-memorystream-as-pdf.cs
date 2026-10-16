// HOW-TO: Sharpen PNG and Convert to PDF in Memory Stream C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                using (MemoryStream ms = new MemoryStream())
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    raster.Save(ms, pdfOptions);
                    Console.WriteLine($"PDF saved to memory stream, length: {ms.Length}");
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
 * 1. When you need to enhance a scanned PNG screenshot before embedding it into a PDF report generated on the fly.
 * 2. When an e‑commerce platform wants to sharpen product PNG images and deliver them as PDF receipts without writing temporary files to disk.
 * 3. When a document‑generation service must apply a sharpening filter to user‑uploaded PNG logos and stream the resulting PDF directly to a web client.
 * 4. When a batch job processes PNG assets, improves their clarity, and stores the PDFs in a memory buffer for further encryption or compression.
 * 5. When a Windows desktop application requires converting edited PNG graphics to PDF for printing, using a MemoryStream to avoid intermediate file I/O.
 */
