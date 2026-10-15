// HOW-TO: Batch Convert ODG and OTG Files to PDF with Fixed Page Size in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
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

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".odg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".otg", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = 595,
                            PageHeight = 842,
                            BackgroundColor = Color.White
                        };
                        image.Save(outputPath, pdfOptions);
                    }
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
 * 1. When a company needs to archive a collection of OpenDocument graphics (ODG) and OpenDocument templates (OTG) as searchable PDFs with a consistent A4 layout.
 * 2. When an automated build pipeline must transform mixed ODG/OTG design assets into PDF reports for client delivery without manual intervention.
 * 3. When a desktop application processes user‑uploaded ODG or OTG drawings and generates printable PDFs with a white background and uniform page dimensions.
 * 4. When a migration script moves legacy OpenDocument graphics from a file share to a PDF‑based document management system, ensuring each page matches the same size.
 * 5. When a batch job runs nightly to convert newly added ODG and OTG files in a folder to PDF for compliance auditing, preserving page size across all documents.
 */
