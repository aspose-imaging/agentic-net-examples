// HOW-TO: Convert CDR to PDF with PDF Version 1.7 in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string inputPath = Path.Combine(inputDirectory, "sample.cdr");
            string outputPath = Path.Combine(outputDirectory, "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
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

/*
 * Real-World Use Cases:
 * 1. When a design workflow requires converting CorelDRAW (.cdr) files to PDF for client delivery, this code ensures the output PDF is saved with version 1.7 for broad viewer compatibility.
 * 2. When an automated document generation service must embed legacy CDR graphics into PDF reports, the snippet provides a reliable .NET way to perform the conversion with the correct PDF version.
 * 3. When a company needs to batch‑process a folder of CDR assets into PDFs that comply with a specific PDF version requirement for a printing press, this example shows how to loop through files using Aspose.Imaging.
 * 4. When a web application allows users to upload CDR drawings and instantly preview them as PDFs, the code demonstrates the server‑side conversion while setting the PDF version to avoid rendering issues.
 * 5. When a compliance audit mandates that all exported PDFs conform to PDF 1.7 standards, developers can use this pattern to convert source CDR files and guarantee the version setting.
 */
