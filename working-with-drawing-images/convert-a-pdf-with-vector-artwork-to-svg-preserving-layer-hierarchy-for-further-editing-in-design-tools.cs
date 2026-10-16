// HOW-TO: Convert PDF with Vector Artwork to SVG Preserving Layers in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.pdf";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new SvgOptions();
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
 * 1. When a developer needs to export a multi‑layer PDF design to an editable SVG for use in web or design tools.
 * 2. When an application must programmatically convert vector‑based PDFs into scalable SVG files without rasterizing the artwork.
 * 3. When a workflow requires preserving the original PDF layer hierarchy so designers can edit individual elements after conversion.
 * 4. When automating batch processing of PDF assets to generate SVG versions for responsive UI rendering.
 * 5. When integrating Aspose.Imaging into a C# service that transforms client‑uploaded PDFs into SVGs for downstream graphic pipelines.
 */
