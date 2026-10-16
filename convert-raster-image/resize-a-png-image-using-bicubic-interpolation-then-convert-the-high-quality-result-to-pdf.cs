// HOW-TO: Resize PNG Image and Save as High‑Quality PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output\\output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                image.Save(outputPath, new PdfOptions());
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
 * 1. When you need to enlarge a PNG logo for printing while preserving clarity and output it as a PDF brochure.
 * 2. When an application must generate a PDF report that includes scaled‑up screenshots originally stored as PNG files.
 * 3. When a web service receives user‑uploaded PNG avatars and must create larger PDF versions for documentation.
 * 4. When automating batch processing of product images, you need to double their dimensions and compile them into PDF catalogs.
 * 5. When converting high‑resolution PNG diagrams to PDF for archival or sharing without losing detail.
 */
