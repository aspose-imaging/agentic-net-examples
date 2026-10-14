// HOW-TO: Convert JPEG to PDF and Verify File Creation in C# (Aspose.Imaging for .NET)
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

namespace ImageToPdfConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input/input.jpg";
                string outputPath = "output/output.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new PdfOptions();
                    image.Save(outputPath, options);
                }

                if (File.Exists(outputPath))
                {
                    Console.WriteLine("PDF file created successfully.");
                }
                else
                {
                    Console.Error.WriteLine("Failed to create PDF file.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a PDF report from a user‑uploaded JPEG image and confirm the file was saved correctly.
 * 2. When automating batch processing of scanned photos into PDFs for archival and you must ensure each PDF is created before moving on.
 * 3. When building a web service that converts product images to PDFs for printing and you want to validate the output file exists.
 * 4. When integrating image‑to‑PDF conversion into a desktop application that logs success or failure of the conversion.
 * 5. When creating a scheduled task that transforms camera snapshots into PDFs and needs to check the conversion succeeded to trigger downstream workflows.
 */
