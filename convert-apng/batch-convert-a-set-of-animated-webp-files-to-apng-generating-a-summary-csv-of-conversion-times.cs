// HOW-TO: Batch Convert Animated WebP Files to APNG with Timing CSV in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.webp");
            var summaryLines = new List<string>();
            summaryLines.Add("InputFile,OutputFile,TimeMs");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".apng");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var start = DateTime.Now;
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new ApngOptions());
                }
                var elapsedMs = (DateTime.Now - start).TotalMilliseconds;

                summaryLines.Add($"{Path.GetFileName(inputPath)},{Path.GetFileName(outputPath)},{elapsedMs}");
            }

            string csvPath = Path.Combine(outputDirectory, "summary.csv");
            Directory.CreateDirectory(Path.GetDirectoryName(csvPath));
            File.WriteAllLines(csvPath, summaryLines);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a collection of animated WebP images to APNG for web browsers that support PNG animation while tracking how long each conversion takes.
 * 2. When you want to automate the processing of user‑uploaded WebP stickers into APNG format for a messaging app and log performance metrics.
 * 3. When you are preparing a game asset pipeline that requires all animated textures in APNG and need a CSV report to benchmark conversion speed.
 * 4. When you are migrating legacy animated WebP graphics to a format compatible with iOS apps and need a summary file for quality assurance.
 * 5. When you are building a CI/CD step that validates image conversion times for animated assets and stores the results in a CSV for analysis.
 */
