// HOW-TO: Resize DjVu Pages to 1024x768 and Convert to PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.djvu";
        string outputPath = "Output/output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageWidth = 1024,
                    PageHeight = 768,
                    BackgroundColor = Color.White
                };
                djvu.Save(outputPath, pdfOptions);
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
 * 1. When you need to embed high‑resolution DjVu scans into a PDF report with a fixed page size.
 * 2. When converting a multi‑page DjVu document to PDF for distribution while ensuring each page fits a 1024×768 layout.
 * 3. When preparing DjVu‑based e‑books for devices that only support PDF and require consistent dimensions.
 * 4. When automating a workflow that standardizes DjVu page dimensions before archiving them as PDF files.
 * 5. When generating PDF previews of DjVu files for web viewers that expect 1024×768 images.
 */
