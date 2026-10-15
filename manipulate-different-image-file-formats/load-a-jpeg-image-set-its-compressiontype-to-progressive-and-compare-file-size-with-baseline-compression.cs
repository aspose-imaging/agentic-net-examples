// HOW-TO: Compare Baseline and Progressive JPEG File Sizes in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string baselinePath = "output/baseline.jpg";
            string progressivePath = "output/progressive.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(baselinePath));
            Directory.CreateDirectory(Path.GetDirectoryName(progressivePath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Save baseline (default compression)
                var baselineOptions = new JpegOptions();
                image.Save(baselinePath, baselineOptions);
            }

            // Load again for progressive save
            using (Image image = Image.Load(inputPath))
            {
                var progressiveOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive
                };
                image.Save(progressivePath, progressiveOptions);
            }

            // Compare file sizes
            long baselineSize = new FileInfo(baselinePath).Length;
            long progressiveSize = new FileInfo(progressivePath).Length;

            Console.WriteLine($"Baseline size: {baselineSize} bytes");
            Console.WriteLine($"Progressive size: {progressiveSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to determine whether using progressive JPEG compression reduces bandwidth for web page images.
 * 2. When you want to generate two versions of a photo—standard and progressive—to compare their storage requirements before choosing a delivery format.
 * 3. When optimizing a mobile app’s asset bundle and you must verify that progressive JPEGs fit within a size budget.
 * 4. When performing automated quality checks in a CI pipeline to ensure that switching to progressive compression does not unexpectedly increase file size.
 * 5. When building a content‑management system that offers both baseline and progressive JPEG options and you need to log the size difference for analytics.
 */
