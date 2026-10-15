// HOW-TO: How to Reduce JPEG File Size by Setting Quality to 75% in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            long originalSize = new FileInfo(inputPath).Length;

            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Quality = 75
                };
                image.Save(outputPath, jpegOptions);
            }

            long newSize = new FileInfo(outputPath).Length;
            double reduction = (originalSize - newSize) * 100.0 / originalSize;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"New size: {newSize} bytes");
            Console.WriteLine($"Size reduction: {reduction:F2}%");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to shrink large JPEG photos for web upload while controlling quality in a C# application.
 * 2. When you want to generate optimized thumbnails with a specific compression level to meet bandwidth constraints.
 * 3. When you must compare original and compressed image sizes to verify that a chosen quality setting meets storage targets.
 * 4. When you are building an automated batch processor that reduces JPEG file sizes before archiving them.
 * 5. When you need to report the percentage of size reduction after applying a 75% quality setting for logging or analytics.
 */
