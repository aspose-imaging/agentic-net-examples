// HOW-TO: Convert ODG to PDF with Custom DPI in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
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
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions options = new PdfOptions())
                {
                    options.ResolutionSettings = new ResolutionSetting(300, 300);
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
 * 1. When you need to generate high‑resolution PDF reports from OpenDocument graphics (ODG) files in a C# application.
 * 2. When a document management system must preserve vector quality by converting ODG drawings to PDF at a specific DPI.
 * 3. When automating batch processing of design assets, you can convert multiple ODG files to PDF with a uniform 300 dpi resolution.
 * 4. When integrating Aspose.Imaging into a workflow that requires PDF output for printing, setting the resolution ensures the printed pages match the intended size.
 * 5. When a web service receives ODG uploads and must return printable PDFs with consistent image density, this code provides a simple C# solution.
 */
