// HOW-TO: Convert BMP Image to PDF and Stream to HTTP Response in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.bmp";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Stream responseStream = Console.OpenStandardOutput())
            {
                using (Image image = Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                        image.Save(responseStream, pdfOptions);
                    }
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
 * 1. When you need to serve dynamically generated PDF versions of uploaded BMP files directly to a web browser without creating intermediate files.
 * 2. When a web service must convert user‑submitted BMP images to PDF on the fly and return the result as an HTTP response stream.
 * 3. When building an ASP.NET endpoint that provides printable PDF documents from legacy BMP assets for downstream processing.
 * 4. When integrating Aspose.Imaging into a REST API to transform image formats and deliver the PDF output to client applications instantly.
 * 5. When optimizing server storage by streaming converted PDFs instead of saving temporary files after converting BMP images.
 */
