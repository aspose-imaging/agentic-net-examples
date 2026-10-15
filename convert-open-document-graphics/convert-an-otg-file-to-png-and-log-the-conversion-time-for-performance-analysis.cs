// HOW-TO: Convert OTG to PNG and Measure Conversion Time in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.otg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var stopwatch = Stopwatch.StartNew();

            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions();
                image.Save(outputPath, options);
            }

            stopwatch.Stop();
            Console.WriteLine($"Conversion time: {stopwatch.ElapsedMilliseconds} ms");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert legacy OTG design files to PNG thumbnails while tracking how long each conversion takes for performance tuning.
 * 2. When building an automated pipeline that processes incoming OTG assets and logs conversion speed to identify bottlenecks.
 * 3. When creating a web service that serves PNG previews of OTG diagrams and requires timing metrics to meet SLA requirements.
 * 4. When migrating a large archive of OTG files to a web‑friendly format and want to record conversion times for reporting.
 * 5. When profiling the Aspose.Imaging library on different hardware to compare OTG‑to‑PNG conversion performance in a C# application.
 */
