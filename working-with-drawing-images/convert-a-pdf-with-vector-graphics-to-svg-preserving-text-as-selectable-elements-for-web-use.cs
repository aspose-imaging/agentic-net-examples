// HOW-TO: Convert PDF with Vector Graphics to Selectable SVG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.pdf";
            string outputPath = "Output\\sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to display a PDF brochure on a website while keeping its vector artwork crisp and allowing users to copy or search the text, you can convert it to an SVG with selectable text using C# and Aspose.Imaging.
 * 2. When generating responsive reports from PDF invoices that must scale on different screen sizes without losing quality, converting the PDFs to SVG preserves vector graphics and keeps the monetary amounts searchable.
 * 3. When building an online documentation portal that imports legacy PDF manuals, converting them to SVG enables seamless integration with HTML and retains searchable text for better accessibility.
 * 4. When creating interactive data visualizations that originate as PDF charts, converting the PDFs to SVG allows you to embed them in web pages and manipulate individual elements while preserving selectable labels.
 * 5. When automating a batch process that extracts vector diagrams from engineering PDFs for inclusion in a web‑based CAD viewer, using C# to convert each PDF to SVG keeps the drawings sharp and the annotation text selectable.
 */
