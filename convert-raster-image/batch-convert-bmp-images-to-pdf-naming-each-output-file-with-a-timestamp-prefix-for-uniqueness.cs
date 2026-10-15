// HOW-TO: Batch Convert BMP Files to PDF with Timestamped Filenames in C# (Aspose.Imaging for .NET)
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
                string inputDirectory = @"C:\InputImages";
                string outputDirectory = @"C:\OutputPdfs";

                // Get all BMP files in the input directory
                string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

                foreach (string inputPath in bmpFiles)
                {
                    // Verify the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Create a timestamp prefix for uniqueness
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, $"{timestamp}_{fileNameWithoutExt}.pdf");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load BMP and save as PDF
                    using (Image image = Image.Load(inputPath))
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
 * 1. When you need to archive a collection of BMP screenshots as PDF documents while ensuring each file has a unique timestamped name.
 * 2. When an automated workflow must convert scanned BMP images from a scanner into PDF reports without overwriting existing files.
 * 3. When a server‑side application processes user‑uploaded BMP graphics and stores them as PDFs with a timestamp prefix for version control.
 * 4. When you want to generate PDF portfolios from BMP assets in a folder, using C# to create uniquely named output files for later retrieval.
 * 5. When a batch job must transform legacy BMP assets into PDF format for compliance, adding a precise timestamp to each filename to track processing time.
 */
