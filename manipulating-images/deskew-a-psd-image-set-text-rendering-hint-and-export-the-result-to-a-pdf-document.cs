// HOW-TO: Deskew PSD Image and Convert to PDF in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.psd");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.NormalizeAngle(false, Color.LightGray);

                PdfOptions pdfOptions = new PdfOptions();

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
 * 1. When you need to automatically straighten scanned Photoshop files before generating printable PDF reports.
 * 2. When a web service must accept user‑uploaded PSD artwork, correct its rotation, and deliver a PDF preview.
 * 3. When an automated workflow converts layered design files into PDF for archiving while ensuring the image is properly aligned.
 * 4. When a desktop application prepares marketing assets by deskewing PSD logos and exporting them as PDF for client review.
 * 5. When a batch job processes a folder of PSD files, normalizes their angles, and saves each as a PDF for downstream printing pipelines.
 */
