// HOW-TO: Batch Convert Multiple BMP Images to PDF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchBmpToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "InputBmpFiles";
                string outputDirectory = "OutputPdfFiles";

                // Get all BMP files in the input directory
                string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

                foreach (string inputPath in bmpFiles)
                {
                    // Verify the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Build the output PDF path with the same filename (different extension)
                    string outputPath = Path.Combine(
                        outputDirectory,
                        Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the BMP image and save as PDF
                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath, new PdfOptions());
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
 * 1. When you need to automatically transform a folder of legacy BMP scans into searchable PDF documents for archiving.
 * 2. When a desktop application must generate PDF reports from user‑uploaded BMP graphics without manual file handling.
 * 3. When a server‑side service processes incoming BMP assets in bulk and stores them as PDFs for downstream workflow.
 * 4. When you want to preserve the original filenames while converting BMP pictures to PDF for consistent naming conventions.
 * 5. When you require a simple C# script that iterates through a directory, creates missing output folders, and saves each BMP as a PDF using Aspose.Imaging.
 */
