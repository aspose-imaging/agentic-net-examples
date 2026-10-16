// HOW-TO: Parallel Batch Convert CMX Files To PDF In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchConversionTests
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\TestData\CMXInput";
            string outputDirectory = @"C:\TestData\PDFOutput";

            try
            {
                // Ensure the base output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Retrieve all CMX files from the input directory (including subfolders)
                string[] inputFiles = Directory.GetFiles(inputDirectory, "*.cmx", SearchOption.AllDirectories);

                // Process each file in parallel
                Parallel.ForEach(inputFiles, inputPath =>
                {
                    // Verify the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine the relative path and construct the corresponding output PDF path
                    string relativePath = Path.GetRelativePath(inputDirectory, inputPath);
                    string outputPath = Path.Combine(outputDirectory, Path.ChangeExtension(relativePath, ".pdf"));

                    // Ensure the output directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the CMX image and save it as PDF
                    using (Image image = Image.Load(inputPath))
                    {
                        var pdfOptions = new PdfOptions();
                        image.Save(outputPath, pdfOptions);
                    }

                    // Simple verification that the PDF was created
                    if (File.Exists(outputPath))
                    {
                        Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                    }
                    else
                    {
                        Console.Error.WriteLine($"Conversion failed for: {inputPath}");
                    }
                });
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
 * 1. When a company needs to automatically transform large collections of legacy CorelDRAW CMX drawings into searchable PDF documents for archiving.
 * 2. When a build pipeline must generate PDF reports from CMX assets in multiple subfolders without slowing down the build, using parallel processing.
 * 3. When a desktop application offers users a one‑click “Export All” feature that converts every CMX file in a selected folder hierarchy to PDF.
 * 4. When a migration script moves design files from an old CAD system to a document management system that only accepts PDF, requiring batch conversion.
 * 5. When a testing framework validates that each CMX file can be loaded and saved as PDF, ensuring image fidelity across thousands of files.
 */
