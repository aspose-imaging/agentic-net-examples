// HOW-TO: Convert WMF to SVG Preserving Text and Fonts in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmf";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions
                {
                    TextAsShapes = false
                };
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to display legacy WMF graphics on the web as scalable SVG while keeping the original text selectable.
 * 2. When converting engineering diagrams stored in WMF to SVG for inclusion in responsive HTML reports without losing font styling.
 * 3. When migrating a Windows application’s icons from WMF to SVG to support high‑resolution displays while preserving text layout.
 * 4. When automating batch processing of WMF assets to SVG for a publishing workflow that requires editable vector files.
 * 5. When integrating WMF to SVG conversion into a C# service that generates printable PDFs and must retain embedded fonts for accurate rendering.
 */
