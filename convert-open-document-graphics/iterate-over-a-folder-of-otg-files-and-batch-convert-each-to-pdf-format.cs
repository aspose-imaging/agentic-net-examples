// HOW-TO: Batch Convert OTG Files to PDF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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

namespace OtgToPdfBatchConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "C:\\OTGInput";
                string outputFolder = "C:\\OTGOutput";

                // Ensure the base output directory exists
                Directory.CreateDirectory(outputFolder);

                foreach (string inputPath in Directory.GetFiles(inputFolder, "*.otg"))
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        var pdfOptions = new PdfOptions();
                        image.Save(outputPath, pdfOptions);
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
 * 1. When a company receives multiple OTG design files from a client and needs to generate PDF proofs for review without opening each file manually.
 * 2. When an automated nightly job must archive all OTG images from a shared directory into PDF format for long‑term storage.
 * 3. When a document management system imports OTG graphics and requires them to be stored as searchable PDFs for compliance reporting.
 * 4. When a Windows service processes incoming OTG scans in a drop folder and converts them to PDFs to be attached to email notifications.
 * 5. When a migration script moves legacy OTG assets to a new PDF‑based workflow, converting each file in a batch to preserve file names and folder structure.
 */
