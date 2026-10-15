// HOW-TO: Combine Multiple PSD Files Into a Single PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string psdPath1 = "Input/first.psd";
            string psdPath2 = "Input/second.psd";
            string outputPdf = "Output/combined.pdf";

            if (!File.Exists(psdPath1))
            {
                Console.Error.WriteLine($"File not found: {psdPath1}");
                return;
            }
            if (!File.Exists(psdPath2))
            {
                Console.Error.WriteLine($"File not found: {psdPath2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPdf));

            List<Image> images = new List<Image>();
            images.Add(Image.Load(psdPath1));
            images.Add(Image.Load(psdPath2));

            using (Image result = Image.Create(images.ToArray(), true))
            {
                PdfOptions pdfOptions = new PdfOptions();
                result.Save(outputPdf, pdfOptions);
            }

            foreach (var img in images)
            {
                img.Dispose();
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
 * 1. When you need to merge several Photoshop PSD layers or files into a multi‑page PDF report for client review.
 * 2. When automating the creation of a printable catalog by converting each product’s PSD design into separate PDF pages.
 * 3. When generating a PDF portfolio from a series of PSD artwork files for easy sharing or archiving.
 * 4. When building a batch process that consolidates PSD‑based invoices into a single PDF document for accounting systems.
 * 5. When developing a web service that receives PSD uploads and returns a combined PDF for downstream workflow integration.
 */
