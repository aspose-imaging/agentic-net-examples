// HOW-TO: Batch Convert BMP Images to PDF with Sequential Filenames in C# (Aspose.Imaging for .NET)
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
                string inputDirectory = @"C:\InputBmp";
                string outputDirectory = @"C:\OutputPdf";

                // Get all BMP files in the input directory
                string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

                int counter = 1;
                foreach (string bmpPath in bmpFiles)
                {
                    // Verify the input file exists
                    if (!File.Exists(bmpPath))
                    {
                        Console.Error.WriteLine($"File not found: {bmpPath}");
                        continue;
                    }

                    // Load the BMP image
                    using (Image image = Image.Load(bmpPath))
                    {
                        // Prepare output file path with sequential numeric suffix
                        string outputPath = Path.Combine(outputDirectory, $"{counter}.pdf");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save as PDF
                        var pdfOptions = new PdfOptions();
                        image.Save(outputPath, pdfOptions);
                    }

                    counter++;
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
 * 1. When you need to archive a large collection of scanned BMP documents as PDF files with simple numeric ordering.
 * 2. When a legacy system generates BMP screenshots and you must package them into PDF reports automatically.
 * 3. When preparing image assets for a printing workflow that requires PDFs named sequentially for batch processing.
 * 4. When migrating BMP graphics from a file server to a PDF‑based document management system without manual renaming.
 * 5. When creating numbered PDF pages from BMP diagrams for inclusion in technical manuals or presentations.
 */
