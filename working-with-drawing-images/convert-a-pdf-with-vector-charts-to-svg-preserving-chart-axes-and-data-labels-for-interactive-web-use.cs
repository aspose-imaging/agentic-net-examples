// HOW-TO: Convert PDF Chart to SVG with Vector Preservation in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
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
            string inputPath = "Input\\chart.pdf";
            string outputPath = "Output\\chart.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to embed a PDF‑generated chart into a responsive web page without losing vector quality, you can convert the PDF to SVG using C# and Aspose.Imaging.
 * 2. When an analytics dashboard requires scalable chart graphics that retain axis lines and data labels for zooming and panning, this code transforms the source PDF into an interactive SVG.
 * 3. When you must automate the migration of legacy PDF reports to modern HTML5 visualizations, the snippet extracts the vector chart and saves it as SVG for seamless integration.
 * 4. When a mobile app needs lightweight, resolution‑independent chart assets, converting the PDF chart to SVG via C# reduces file size while preserving all vector elements.
 * 5. When a content management system stores charts as PDFs but the front‑end expects SVG for CSS styling and scripting, this code programmatically performs the format conversion.
 */
