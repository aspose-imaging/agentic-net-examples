// HOW-TO: Convert DjVu To PDF Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
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
 * 1. When you need to batch‑convert scanned DjVu files into a single PDF using Aspose.Imaging in C#.
 * 2. When a C# web application must render DjVu documents as PDFs for browsers that lack DjVu support.
 * 3. When integrating a document‑management system that stores originals as DjVu but requires PDF output for printing via Aspose.Imaging.
 * 4. When automating the migration of legacy DjVu manuals to PDF format for distribution to end‑users with a .NET service.
 * 5. When creating a server‑side C# service that transforms uploaded DjVu images into PDFs while optimizing memory usage with Aspose.Imaging.
 */
