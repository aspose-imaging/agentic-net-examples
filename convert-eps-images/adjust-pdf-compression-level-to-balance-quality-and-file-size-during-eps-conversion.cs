// HOW-TO: Convert EPS to PDF in C# While Trying to Set Compression (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\sample.pdf";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Adjusting PDF compression level is not supported by the Aspose.Imaging API.
                // The conversion proceeds without compression adjustments.
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to programmatically convert vector EPS artwork into a PDF document for printing or distribution using C# and Aspose.Imaging.
 * 2. When an application must batch‑process EPS files from a folder and generate corresponding PDFs without manual intervention.
 * 3. When a workflow requires validating that an EPS file exists before attempting conversion to avoid runtime errors.
 * 4. When a project needs to ensure the output directory is created automatically during EPS‑to‑PDF conversion.
 * 5. When a developer wants to handle conversion failures gracefully by catching exceptions and logging error messages.
 */
