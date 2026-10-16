// HOW-TO: Log Start and End Times While Converting EPS to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

namespace EPSConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output paths
                string[] inputPaths = new string[]
                {
                    @"C:\Images\input1.eps",
                    @"C:\Images\input2.eps"
                };

                string[] outputPaths = new string[]
                {
                    @"C:\Images\output1.png",
                    @"C:\Images\output2.png"
                };

                for (int i = 0; i < inputPaths.Length; i++)
                {
                    string inputPath = inputPaths[i];
                    string outputPath = outputPaths[i];

                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    Console.WriteLine($"Processing {inputPath} started at {DateTime.Now}");

                    using (Image image = Image.Load(inputPath))
                    {
                        var pngOptions = new PngOptions
                        {
                            ColorType = PngColorType.Grayscale
                        };
                        image.Save(outputPath, pngOptions);
                    }

                    Console.WriteLine($"Processing {inputPath} completed at {DateTime.Now}");
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
 * 1. When you need to batch‑convert multiple EPS illustrations to grayscale PNGs and keep a timestamp log for each file to monitor processing duration.
 * 2. When an automated publishing pipeline must verify that each EPS source exists before conversion and record start and finish times for audit purposes.
 * 3. When you want to create a simple console utility that saves converted images to a specific folder structure while tracking conversion times for performance analysis.
 * 4. When integrating Aspose.Imaging into a C# application that requires error‑free handling of missing EPS files and detailed timing information for troubleshooting.
 * 5. When generating reports on image conversion throughput, you need to capture the exact moment each EPS file begins and ends processing using DateTime stamps.
 */
