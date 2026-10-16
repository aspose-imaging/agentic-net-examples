// HOW-TO: Apply Ordered Dithering to PSD and Convert to PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = @"C:\Images\input.psd";
            string outputPath = @"C:\Images\output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage rasterImage)
                {
                    // Apply ordered (threshold) dithering with 8-bit palette (256 colors)
                    rasterImage.Dither(DitheringMethod.ThresholdDithering, 8);
                }

                var pdfOptions = new PdfOptions();
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
 * 1. When you need to reduce a large PSD file to a smaller 256‑color PDF for faster web preview.
 * 2. When preparing print‑ready PDFs from layered Photoshop files while preserving visual quality with ordered dithering.
 * 3. When automating batch conversion of PSD assets to PDF in a C# backend service that requires consistent color palette.
 * 4. When generating PDF reports that embed PSD graphics and need deterministic threshold dithering to avoid banding.
 * 5. When integrating Aspose.Imaging into a document workflow to transform PSD images into PDF format with controlled color depth.
 */
