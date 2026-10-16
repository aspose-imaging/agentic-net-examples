// HOW-TO: Batch Convert Multiple EPS Files to PDF Using C# Loop (Aspose.Imaging for .NET)
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

namespace BatchEpsToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = "input";
                string outputDirectory = "output";

                Directory.CreateDirectory(inputDirectory);
                string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

                foreach (string inputPath in epsFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
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
 * 1. When you need to automatically generate PDF reports from a folder of EPS graphics for printing or archiving.
 * 2. When a web service must convert user‑uploaded EPS logos to PDF before storing them in a document management system.
 * 3. When a build pipeline has to transform a collection of vector EPS assets into PDF for inclusion in generated documentation.
 * 4. When a desktop application processes design files in bulk, converting each EPS illustration to a PDF for client delivery.
 * 5. When an automated script scans a directory of EPS files and creates PDF versions to ensure compatibility with downstream PDF‑only workflows.
 */
