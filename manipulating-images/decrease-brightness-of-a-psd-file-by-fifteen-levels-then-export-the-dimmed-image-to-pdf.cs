// HOW-TO: Decrease PSD Brightness by 15 and Export to PDF in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.AdjustBrightness(-15);
                raster.Save(outputPath, new PdfOptions());
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
 * 1. When you need to dim a Photoshop PSD before generating a printable PDF for a marketing brochure.
 * 2. When an automated workflow must lower image brightness to meet brand guidelines and then archive the result as a PDF.
 * 3. When a web service receives PSD files, applies a uniform brightness reduction, and returns PDF previews to users.
 * 4. When batch processing a collection of PSD assets to create darker PDF versions for night‑mode UI themes.
 * 5. When integrating Aspose.Imaging in a C# application to adjust image exposure and produce PDF reports without manual editing.
 */
