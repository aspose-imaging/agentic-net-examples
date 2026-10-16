// HOW-TO: Measure EPS to PDF Conversion Time with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");
            foreach (string epsPath in epsFiles)
            {
                if (!File.Exists(epsPath))
                {
                    Console.Error.WriteLine($"File not found: {epsPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(epsPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();

                using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Aspose.Imaging.Image.Load(epsPath))
                {
                    using (var pdfOptions = new PdfOptions())
                    {
                        epsImage.Save(outputPath, pdfOptions);
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($"Converted {fileName}.eps to PDF in {stopwatch.ElapsedMilliseconds} ms");
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
 * 1. When you need to benchmark how long batch converting EPS artwork to PDF takes in a C# application.
 * 2. When you want to log conversion performance for each EPS file to identify slow files in an automated publishing pipeline.
 * 3. When you are optimizing server resources and need precise timing data for EPS‑to‑PDF transformations using Aspose.Imaging.
 * 4. When you must generate a performance report for converting vector EPS graphics to PDF in a .NET batch job.
 * 5. When you are troubleshooting latency issues in a document conversion service and need per‑file timing metrics.
 */
