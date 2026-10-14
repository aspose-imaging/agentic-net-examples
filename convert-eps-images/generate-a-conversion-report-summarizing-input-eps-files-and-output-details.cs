// HOW-TO: Generate PDF and PNG from EPS Files with Report in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            var report = new System.Text.StringBuilder();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                if (!string.Equals(Path.GetExtension(inputPath), ".eps", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string pdfPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");
                string pngPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));
                Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(pdfPath, pdfOptions);
                    }

                    using (PngOptions pngOptions = new PngOptions())
                    {
                        image.Save(pngPath, pngOptions);
                    }
                }

                report.AppendLine($"Input: {inputPath}");
                report.AppendLine($"PDF Output: {pdfPath}");
                report.AppendLine($"PNG Output: {pngPath}");
                report.AppendLine("---");
            }

            string reportPath = Path.Combine(outputDirectory, "ConversionReport.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));
            File.WriteAllText(reportPath, report.ToString());

            Console.WriteLine($"Conversion report saved to: {reportPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert a collection of EPS artwork into PDF for printing and PNG for web preview while tracking the conversion results.
 * 2. When an automated build process must create portable PDF documents and thumbnail PNG images from vector EPS assets stored in a source folder.
 * 3. When a server‑side service has to accept user‑uploaded EPS files, transform them into PDF and PNG formats, and log the output paths for further processing.
 * 4. When a desktop utility is required to generate a conversion summary report for each EPS file converted to PDF and PNG in a specified output directory.
 * 5. When integrating Aspose.Imaging into a C# application to ensure EPS files are rendered correctly as high‑resolution PNGs and searchable PDFs for archival purposes.
 */
