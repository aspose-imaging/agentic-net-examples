// HOW-TO: Rasterize ODG to High‑Resolution JPEG at 300 DPI in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (Aspose.Imaging.FileFormats.OpenDocument.OdgImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300)
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert OpenDocument graphics (ODG) into print‑ready JPEG files with 300 dpi for high‑quality brochures.
 * 2. When an application must generate high‑resolution thumbnails of ODG diagrams for inclusion in PDF reports.
 * 3. When a web service exports user‑created ODG drawings as JPEG images optimized for large‑format printing.
 * 4. When automating archival of ODG artwork, preserving detail by rasterizing to JPEG at 300 dpi before storage.
 * 5. When integrating Aspose.Imaging into a C# workflow that requires consistent DPI settings across all converted images for downstream image processing.
 */
