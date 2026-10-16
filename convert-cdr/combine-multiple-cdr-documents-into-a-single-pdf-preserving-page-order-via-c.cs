// HOW-TO: Combine Multiple CDR Files Into a Single PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");
            if (files.Length == 0)
            {
                Console.WriteLine("No CDR files found in the input directory.");
                return;
            }

            List<Image> images = new List<Image>();
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                Image img = Image.Load(filePath);
                images.Add(img);
            }

            string outputPath = Path.Combine(outputDirectory, "Combined.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image result = Image.Create(images.ToArray(), true))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    result.Save(outputPath, pdfOptions);
                }
            }

            foreach (Image img in images)
            {
                img.Dispose();
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
 * 1. When a design studio needs to merge several CorelDRAW (.cdr) drawings into one PDF portfolio while keeping the original page sequence.
 * 2. When an automated build pipeline must convert a batch of CDR assets into a single PDF report for distribution to clients.
 * 3. When a document management system requires consolidating multiple CDR diagrams into a searchable PDF document using C#.
 * 4. When a Windows service processes incoming CDR files and creates a combined PDF invoice without manual intervention.
 * 5. When a desktop application lets users select multiple CDR files and export them as a single PDF booklet preserving layout order.
 */
