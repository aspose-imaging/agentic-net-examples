// HOW-TO: Batch Convert Raster Images to PDF with Original Filenames in C# (Aspose.Imaging for .NET)
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

namespace RasterToPdfBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = @"C:\InputImages";
                string outputFolder = @"C:\OutputPdfs";

                var files = Directory.GetFiles(inputFolder);
                foreach (var inputPath in files)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var image = Image.Load(inputPath))
                    {
                        var pdfOptions = new PdfOptions();
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
 * 1. When you need to generate PDF reports from a folder of scanned JPEG or PNG files while keeping each PDF named the same as its source image.
 * 2. When an automated workflow must archive a collection of product photos as PDFs for compliance without manually renaming each file.
 * 3. When a desktop application processes user‑uploaded screenshots and saves them as PDFs for easy printing or sharing.
 * 4. When a server‑side service converts a batch of medical imaging files (e.g., BMP) to PDFs for integration with electronic health record systems.
 * 5. When a migration script moves legacy raster assets into a PDF‑based document repository while preserving the original file names.
 */
