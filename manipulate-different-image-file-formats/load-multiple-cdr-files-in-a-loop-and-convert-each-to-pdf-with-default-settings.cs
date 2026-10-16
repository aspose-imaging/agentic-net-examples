// HOW-TO: Batch Convert Multiple CDR Files to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
                // Hardcoded input CDR file paths
                string[] inputPaths = new string[]
                {
                    @"C:\Images\file1.cdr",
                    @"C:\Images\file2.cdr",
                    @"C:\Images\file3.cdr"
                };

                foreach (string inputPath in inputPaths)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.ChangeExtension(inputPath, ".pdf");
                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath, new PdfOptions());
                    }

                    Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
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
 * 1. When you need to automate the conversion of a collection of CorelDRAW (CDR) drawings into PDF documents for archiving or distribution.
 * 2. When a desktop or server application must process several CDR files in a single run without manual intervention.
 * 3. When you want to generate PDF versions of design assets on the fly before sending them to a printing service.
 * 4. When you are building a migration tool that moves legacy CDR artwork into a PDF‑based workflow.
 * 5. When you need to validate that each CDR file exists, create output folders, and convert them reliably using default Aspose.Imaging settings.
 */
