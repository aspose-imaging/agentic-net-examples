// HOW-TO: Convert ODG to PNG and Measure Conversion Time in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.odg";
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
 * 1. When you need to generate PNG thumbnails from OpenDocument graphics (ODG) files in a .NET batch processing pipeline.
 * 2. When you want to benchmark the performance of ODG to PNG conversion using Aspose.Imaging for C#.
 * 3. When an application must ensure the output directory exists before saving converted images to avoid runtime errors.
 * 4. When you need to handle missing source files gracefully while converting ODG drawings to PNG format.
 * 5. When you are logging conversion latency to optimize image processing workflows in a server‑side C# service.
 */
