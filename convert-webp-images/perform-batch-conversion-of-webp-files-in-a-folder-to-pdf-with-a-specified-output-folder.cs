// HOW-TO: Batch Convert WebP Images to PDF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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

namespace WebPToPdfBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output folders
                string inputFolder = @"C:\WebPInput";
                string outputFolder = @"C:\PdfOutput";

                // Ensure output folder exists
                Directory.CreateDirectory(outputFolder);

                // Get all .webp files in the input folder
                string[] webpFiles = Directory.GetFiles(inputFolder, "*.webp", SearchOption.TopDirectoryOnly);

                foreach (string inputPath in webpFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Determine output PDF path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the WebP image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Save as PDF
                        image.Save(outputPath, new PdfOptions());
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to generate PDF reports from a collection of WebP graphics stored in a folder.
 * 2. When an automated workflow must archive web‑optimized images as PDFs for compliance or record‑keeping.
 * 3. When a desktop application processes user‑uploaded WebP files and saves them as PDFs in a designated output directory.
 * 4. When a server‑side service converts batches of product images from WebP to PDF for printing or distribution.
 * 5. When a migration script moves legacy WebP assets into PDF format to integrate with a PDF‑only documentation system.
 */
