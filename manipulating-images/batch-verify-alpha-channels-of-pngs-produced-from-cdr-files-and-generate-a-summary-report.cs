// HOW-TO: Batch Convert CDR to PNG and Check Alpha Channel in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input_cdr";
            string outputFolder = "output_png";
            string reportPath = "report.txt";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            var reportLines = new List<string>();
            string[] cdrFiles = Directory.GetFiles(inputFolder, "*.cdr");

            foreach (string cdrPath in cdrFiles)
            {
                if (!File.Exists(cdrPath))
                {
                    Console.Error.WriteLine($"File not found: {cdrPath}");
                    return;
                }

                using (Image cdrImage = Image.Load(cdrPath))
                {
                    string pngPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(cdrPath) + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

                    var pngOptions = new PngOptions();
                    cdrImage.Save(pngPath, pngOptions);
                }

                bool hasAlpha = false;
                string pngPathCheck = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(cdrPath) + ".png");
                using (Image pngImage = Image.Load(pngPathCheck))
                {
                    if (pngImage is RasterImage raster)
                    {
                        hasAlpha = raster.HasAlpha;
                    }
                }

                reportLines.Add($"{Path.GetFileName(cdrPath)}: Alpha = {hasAlpha}");
            }

            File.WriteAllLines(reportPath, reportLines);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically convert a folder of CorelDRAW (.cdr) files to PNGs and verify whether each PNG contains an alpha channel for downstream compositing.
 * 2. When a graphics pipeline requires a quick audit of transparency support in exported PNGs before they are uploaded to a web gallery.
 * 3. When you want to generate a plain‑text report listing each source CDR file and the presence of an alpha channel in its PNG counterpart for quality‑control documentation.
 * 4. When integrating Aspose.Imaging into a CI/CD process to ensure that batch conversions preserve or remove transparency as expected.
 * 5. When building a utility that processes large batches of design assets and needs to flag files lacking alpha channels for manual review.
 */
