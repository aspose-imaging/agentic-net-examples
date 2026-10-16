// HOW-TO: Measure WebP to GIF Conversion Time with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

namespace WebPToGifConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\WebPInput";
                string outputDirectory = @"C:\GifOutput";

                // Ensure output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all .webp files in the input directory
                string[] webpFiles = Directory.GetFiles(inputDirectory, "*.webp");

                foreach (string inputPath in webpFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileName + ".gif");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    Stopwatch sw = Stopwatch.StartNew();

                    using (Image image = Image.Load(inputPath))
                    {
                        // Save as GIF using default options
                        image.Save(outputPath, new GifOptions());
                    }

                    sw.Stop();

                    Console.WriteLine($"Converted '{inputPath}' to '{outputPath}' in {sw.ElapsedMilliseconds} ms");
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
 * 1. When you need to batch convert a folder of WebP images to GIFs while tracking how long each conversion takes for performance tuning.
 * 2. When optimizing an image processing pipeline and you want to log the milliseconds spent converting each WebP file to GIF to identify bottlenecks.
 * 3. When generating animated GIF previews from WebP assets and need to ensure the conversion speed meets real‑time requirements.
 * 4. When monitoring server‑side image conversion workloads and require per‑file timing data to scale resources appropriately.
 * 5. When validating that Aspose.Imaging’s WebP‑to‑GIF conversion maintains acceptable latency in a CI/CD test suite.
 */
