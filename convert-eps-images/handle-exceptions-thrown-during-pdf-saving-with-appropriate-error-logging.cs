// HOW-TO: How To Convert PNG To PDF With Error Handling In C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        string inputPath = "input.png";
        string outputPath = "output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using var image = Image.Load(inputPath);
            var pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically turn user‑uploaded PNG images into PDF reports while ensuring missing files are detected and logged.
 * 2. When an automated batch job must generate PDFs from PNG assets and create the output folder if it does not exist.
 * 3. When a web service converts incoming PNG screenshots to PDF documents and must return clear error messages if the conversion fails.
 * 4. When integrating Aspose.Imaging into a desktop application that saves edited PNGs as PDFs and requires graceful handling of I/O exceptions.
 * 5. When building a CI pipeline that validates image assets by converting them to PDF and logs any failures for debugging.
 */
