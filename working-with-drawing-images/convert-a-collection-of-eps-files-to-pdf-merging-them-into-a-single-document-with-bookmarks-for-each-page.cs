// HOW-TO: Convert Multiple EPS Files to Separate PDF Documents in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Eps;
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

            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");
            if (epsFiles.Length == 0)
            {
                Console.WriteLine("No EPS files found in the input directory.");
                return;
            }

            foreach (string file in epsFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (EpsImage epsImage = (EpsImage)Image.Load(file))
                {
                    epsImage.Save(outputPath, new PdfOptions());
                }

                Console.WriteLine($"Converted '{file}' to PDF at '{outputPath}'.");
            }

            Console.WriteLine("All EPS files have been processed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automate batch conversion of legacy EPS artwork into individual PDF files for easy viewing or printing.
 * 2. When a publishing workflow requires converting designer‑provided EPS assets to PDF before uploading to a content management system.
 * 3. When generating PDF versions of vector logos stored as EPS for inclusion in reports or invoices programmatically.
 * 4. When building a desktop tool that scans a folder of EPS drawings and creates corresponding PDFs for archiving.
 * 5. When integrating Aspose.Imaging into a C# service that processes incoming EPS files and outputs PDF files for downstream processing.
 */
