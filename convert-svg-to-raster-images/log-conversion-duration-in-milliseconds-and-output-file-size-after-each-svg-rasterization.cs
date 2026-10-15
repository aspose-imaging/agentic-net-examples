// HOW-TO: Measure SVG to PNG Conversion Time and File Size in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Diagnostics;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var stopwatch = Stopwatch.StartNew();

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
                }

                stopwatch.Stop();

                long fileSize = new FileInfo(outputPath).Length;
                Console.WriteLine($"Converted {fileName}.svg to PNG in {stopwatch.ElapsedMilliseconds} ms, output size: {fileSize} bytes.");
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
 * 1. When you need to batch‑convert a folder of SVG graphics to PNG while tracking how long each conversion takes for performance tuning.
 * 2. When you want to log the resulting PNG file size after rasterization to verify that image dimensions or compression settings meet storage constraints.
 * 3. When you are building a CI pipeline that must report conversion speed and output size for SVG assets to ensure they stay within defined limits.
 * 4. When you need to diagnose slowdowns in an automated image processing workflow by comparing stopwatch timings for each SVG file.
 * 5. When you are creating a usage‑statistics dashboard that displays both conversion duration and resulting file size for each SVG‑to‑PNG operation.
 */
