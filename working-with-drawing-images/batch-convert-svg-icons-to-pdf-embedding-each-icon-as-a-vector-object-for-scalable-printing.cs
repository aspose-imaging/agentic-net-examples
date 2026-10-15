// HOW-TO: Batch Convert SVG Icons to PDF with Vector Preservation in C# (Aspose.Imaging for .NET)
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

namespace SvgToPdfBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "input_svgs";
                string outputDirectory = "output_pdfs";

                // Ensure output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all SVG files in the input directory
                string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

                foreach (string inputPath in svgFiles)
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

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load SVG image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Save as PDF preserving vector data
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
 * 1. When you need to generate print‑ready PDFs from a library of SVG icons while keeping them fully scalable for high‑resolution output.
 * 2. When an automated build process must convert dozens of SVG assets into PDFs for inclusion in a corporate style guide.
 * 3. When a web application exports user‑uploaded SVG graphics as vector PDFs for offline viewing or archival.
 * 4. When a designer wants to batch‑process SVG logo files into PDFs to send to a commercial printer without rasterizing the artwork.
 * 5. When a CI/CD pipeline requires converting SVG UI assets to PDF documents for documentation generation in a .NET environment.
 */
