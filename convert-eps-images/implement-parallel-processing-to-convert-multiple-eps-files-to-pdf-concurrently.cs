// HOW-TO: Convert Multiple EPS Files to PDF in Parallel with C# (Aspose.Imaging for .NET)
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

namespace EpsToPdfConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = "input";
                string outputDirectory = "output";

                if (!Directory.Exists(inputDirectory))
                {
                    Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                    return;
                }

                string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

                Parallel.ForEach(epsFiles, inputPath =>
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    try
                    {
                        using (Image image = Image.Load(inputPath))
                        {
                            var pdfOptions = new PdfOptions();
                            image.Save(outputPath, pdfOptions);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Error processing {inputPath}: {ex.Message}");
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
 * 1. When you need to batch‑convert a folder of EPS vector graphics to PDF documents quickly by leveraging multi‑core CPUs in a C# application.
 * 2. When an automated build or CI pipeline must generate PDF reports from EPS assets without slowing down the overall process.
 * 3. When a web service receives many EPS uploads and must return PDF versions concurrently to improve response time.
 * 4. When a desktop tool processes large design libraries, converting each EPS file to PDF while keeping the UI responsive through parallel execution.
 * 5. When a server‑side batch job has to archive EPS drawings as PDFs and wants to reduce processing time by running conversions in parallel with Aspose.Imaging.
 */
