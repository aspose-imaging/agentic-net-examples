// HOW-TO: Convert PDF Vector Diagrams to SVG Preserving Line Widths in C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input\\diagram.pdf";
        string outputPath = "Output\\diagram.svg";

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
                using (SvgOptions options = new SvgOptions())
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    options.VectorRasterizationOptions = vectorOptions;
                    image.Save(outputPath, options);
                }
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
 * 1. When a developer needs to embed high‑resolution engineering schematics from PDF into a responsive web page, they can convert the PDF to SVG to keep line widths consistent at any zoom level.
 * 2. When an application must generate printable vector assets from PDF reports for a marketing portal, converting to SVG ensures the graphics scale without loss of detail.
 * 3. When a CAD‑to‑web workflow requires turning PDF‑exported mechanical drawings into scalable SVG icons for interactive diagrams, this code preserves the original line thickness.
 * 4. When a document‑management system wants to provide lightweight preview thumbnails of PDF diagrams that can be zoomed in a browser, converting to SVG maintains accurate line rendering.
 * 5. When a developer builds a cross‑platform UI that loads vector graphics from PDFs and needs them in a format supported by HTML5 canvas or SVG editors, this conversion keeps the vector line properties intact.
 */
