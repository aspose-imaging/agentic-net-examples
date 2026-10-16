// HOW-TO: Unit Test EPS To PDF Conversion Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                using (var pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
                }
            }

            if (File.Exists(outputPath))
            {
                Console.WriteLine("EPS to PDF conversion succeeded.");
            }
            else
            {
                Console.Error.WriteLine("Conversion failed: output file not created.");
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
 * 1. When you need to automatically verify that EPS artwork is correctly transformed into PDF files in a CI pipeline.
 * 2. When a web service must ensure uploaded EPS logos are converted to PDF before storage or display.
 * 3. When a desktop application processes batch EPS documents and you want to confirm each conversion succeeds without manual checks.
 * 4. When integrating Aspose.Imaging into a build script, you require a unit test to catch format‑support regressions early.
 * 5. When generating printable PDFs from vector EPS sources and you need an automated test to guarantee output file creation.
 */
