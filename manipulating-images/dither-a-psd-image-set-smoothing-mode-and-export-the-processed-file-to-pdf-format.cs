// HOW-TO: Convert PSD to PDF With Floyd Steinberg Dithering In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.psd";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);

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
 * 1. When you need to generate a printable PDF from a Photoshop PSD while preserving visual detail by applying Floyd‑Steinberg dithering in a C# application.
 * 2. When an automated batch process must convert multiple layered PSD files to PDF format and reduce color banding using Aspose.Imaging’s raster dithering.
 * 3. When a web service creates PDF previews of uploaded PSD artwork and wants to improve contrast on low‑color devices by dithering the image before saving.
 * 4. When a desktop utility converts high‑resolution PSD graphics to PDF for archiving, ensuring consistent output by applying an 8‑bit Floyd‑Steinberg dithering step.
 * 5. When integrating Aspose.Imaging into a C# workflow to transform PSD files into PDF documents with controlled color reduction for faster loading on mobile browsers.
 */
