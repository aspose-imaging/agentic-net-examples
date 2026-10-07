// HOW-TO: Batch Convert PNG Sequences to APNG with Status Report in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            string reportPath = Path.Combine(outputDirectory, "report.txt");

            Directory.CreateDirectory(outputDirectory);

            using (var reportWriter = new StreamWriter(reportPath, false))
            {
                var sequenceDirectories = Directory.GetDirectories(inputDirectory);
                foreach (var seqDir in sequenceDirectories)
                {
                    try
                    {
                        var pngFiles = Directory.GetFiles(seqDir, "*.png")
                                                .OrderBy(f => f)
                                                .ToArray();

                        if (pngFiles.Length == 0)
                        {
                            reportWriter.WriteLine($"{Path.GetFileName(seqDir)}: No PNG files found.");
                            continue;
                        }

                        string firstPath = pngFiles[0];
                        if (!File.Exists(firstPath))
                        {
                            Console.Error.WriteLine($"File not found: {firstPath}");
                            reportWriter.WriteLine($"{Path.GetFileName(seqDir)}: First PNG missing.");
                            continue;
                        }

                        using (RasterImage firstImage = (RasterImage)Image.Load(firstPath))
                        {
                            int width = firstImage.Width;
                            int height = firstImage.Height;

                            string outputPath = Path.Combine(outputDirectory, Path.GetFileName(seqDir) + ".png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            var options = new ApngOptions
                            {
                                Source = new FileCreateSource(outputPath, false)
                            };

                            using (ApngImage apng = (ApngImage)Image.Create(options, width, height))
                            {
                                apng.RemoveAllFrames();

                                foreach (var pngPath in pngFiles)
                                {
                                    if (!File.Exists(pngPath))
                                    {
                                        Console.Error.WriteLine($"File not found: {pngPath}");
                                        continue;
                                    }

                                    using (RasterImage frame = (RasterImage)Image.Load(pngPath))
                                    {
                                        apng.AddFrame(frame);
                                    }
                                }

                                apng.Save();
                            }

                            reportWriter.WriteLine($"{Path.GetFileName(seqDir)}: Success");
                        }
                    }
                    catch (Exception seqEx)
                    {
                        reportWriter.WriteLine($"{Path.GetFileName(seqDir)}: Failed - {seqEx.Message}");
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
 * 1. When you need to automatically turn a folder of frame‑by‑frame PNG images into animated APNG files for a web gallery while tracking which conversions succeeded.
 * 2. When a game development pipeline must generate animated sprites from multiple PNG sequences and produce a log file for quality‑assurance verification.
 * 3. When a marketing team requires batch creation of lightweight animated PNG ads from design assets and wants a simple text report of any missing or failed images.
 * 4. When a server‑side C# service processes user‑uploaded PNG frames into APNG animations and records the conversion outcome for later auditing.
 * 5. When a CI/CD build step needs to convert test‑generated PNG screenshots into APNG animations and output a status report to ensure the build artifact is complete.
 */
