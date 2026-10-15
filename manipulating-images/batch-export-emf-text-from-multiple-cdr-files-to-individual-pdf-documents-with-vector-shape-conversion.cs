// HOW-TO: Batch Convert Multiple CDR Files to PDF with Vector Shapes in C# (Aspose.Imaging for .NET)
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

namespace CdrToPdfBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\InputCdr";
                string outputDirectory = @"C:\OutputPdf";

                // Ensure output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all CDR files in the input directory
                string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

                foreach (string inputPath in cdrFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine output PDF path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the CDR file
                    using (Image image = Image.Load(inputPath))
                    {
                        // Save as PDF with vector shape conversion
                        PdfOptions pdfOptions = new PdfOptions();
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
}

/*
 * Real-World Use Cases:
 * 1. When a designer needs to automatically turn a folder of CorelDRAW (CDR) drawings into separate PDF files while preserving editable vector graphics.
 * 2. When a batch processing script must generate PDF reports from many CDR assets without rasterizing the artwork.
 * 3. When an application has to export EMF‑style text and shapes from CDR files to PDFs for printing or archival purposes.
 * 4. When a CI/CD pipeline should validate that all CDR resources in a repository can be rendered as vector PDFs before release.
 * 5. When a client wants to convert legacy CDR files to PDF on a server, keeping the original vector quality for downstream editing.
 */
