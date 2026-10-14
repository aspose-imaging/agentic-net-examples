// HOW-TO: Validate EPS Image Before Converting to PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.eps");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (!(image is Aspose.Imaging.FileFormats.Eps.EpsImage))
                {
                    Console.Error.WriteLine("Loaded image is not an EPS file.");
                    return;
                }

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
 * 1. When you need to verify that an uploaded file is a genuine EPS before converting it to a PDF report.
 * 2. When automating batch processing of vector EPS graphics to PDF while ensuring only supported formats are handled.
 * 3. When building a web service that accepts user‑submitted EPS files and must confirm the format prior to rendering them as PDFs.
 * 4. When integrating Aspose.Imaging into a desktop application that converts design assets from EPS to PDF only after confirming the file type.
 * 5. When creating a CI pipeline that validates EPS resources and converts them to PDF for documentation generation.
 */
