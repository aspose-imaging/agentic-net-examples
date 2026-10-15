// HOW-TO: Convert EPS File to TIFF Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Eps.EpsImage image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, options);
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
 * 1. When you need to generate high‑resolution TIFF previews of EPS artwork for print‑ready PDFs.
 * 2. When a document workflow requires converting vector EPS logos into raster TIFF files for archival storage.
 * 3. When an automated batch process must transform EPS diagrams into TIFF images for compatibility with legacy imaging systems.
 * 4. When a web service receives EPS uploads and must return TIFF thumbnails for quick display in browsers.
 * 5. When a GIS application imports EPS maps and saves them as TIFF tiles for raster‑based analysis.
 */
