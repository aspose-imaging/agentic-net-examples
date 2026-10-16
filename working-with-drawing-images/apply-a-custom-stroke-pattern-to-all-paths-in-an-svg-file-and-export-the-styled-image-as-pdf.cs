// HOW-TO: Apply Dashed Stroke to SVG Paths and Export as PDF in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(baseDir, "Input", "input.svg");
            string outputPath = Path.Combine(baseDir, "Output", "styled.pdf");
            string tempSvgPath = Path.Combine(baseDir, "Output", "temp.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempSvgPath));

            string svgContent = File.ReadAllText(inputPath);
            string modified = svgContent.Replace("<path ", "<path style=\"stroke-dasharray:5,2;\" ");

            File.WriteAllText(tempSvgPath, modified);

            using (Image image = Image.Load(tempSvgPath))
            {
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
 * 1. When you need to add a consistent dashed outline to all vector shapes in an SVG before generating a printable PDF report.
 * 2. When you want to programmatically style SVG icons with a custom stroke pattern and embed them in a PDF brochure using C#.
 * 3. When you must convert SVG diagrams with highlighted borders into PDF for documentation that requires a specific dash style.
 * 4. When you are automating the preparation of SVG floor plans with uniform stroke dash arrays for PDF distribution to clients.
 * 5. When you need to preprocess SVG assets to include a stroke-dasharray attribute and then batch‑export them as PDFs in a .NET application.
 */
