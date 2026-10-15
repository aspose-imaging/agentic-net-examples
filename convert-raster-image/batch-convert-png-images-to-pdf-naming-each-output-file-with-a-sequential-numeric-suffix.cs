// HOW-TO: Batch Convert PNG Files to Sequentially Named PDFs in C# (Aspose.Imaging for .NET)
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

namespace BatchPngToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputDirectory = @"C:\InputPngs";
                string outputDirectory = @"C:\OutputPdfs";

                string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");
                int index = 1;

                foreach (string inputPath in pngFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string outputPath = Path.Combine(outputDirectory, $"output_{index}.pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath, new PdfOptions());
                    }

                    index++;
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
 * 1. When you need to generate a series of PDF reports from a folder of PNG screenshots, automatically naming each PDF with a numeric suffix.
 * 2. When an application must archive scanned PNG images as PDFs for easier distribution while preserving order.
 * 3. When a batch processing job has to convert user‑uploaded PNG assets into PDFs for printing, creating files like output_1.pdf, output_2.pdf, etc.
 * 4. When you want to automate the creation of PDF portfolios from PNG design mockups, ensuring each file is saved in a target directory with incremental names.
 * 5. When a backend service processes large numbers of PNG charts and needs to store them as compact PDF documents with predictable filenames for later retrieval.
 */
