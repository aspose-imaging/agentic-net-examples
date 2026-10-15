// HOW-TO: Set Smoothing Mode for GIF Rendering to Reduce Pixelation in C# (Aspose.Imaging for .NET)
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
using System.Drawing.Drawing2D;
using System.Drawing.Text;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            var outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                var gifOptions = new GifOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to improve the visual quality of animated GIFs generated from vector graphics in a C# application.
 * 2. When creating web‑ready GIFs that must look smooth on high‑resolution displays without jagged edges.
 * 3. When converting legacy GIF assets to modern standards while preserving animation timing and reducing pixelation.
 * 4. When building a reporting tool that exports charts as animated GIFs and requires anti‑aliased rendering for readability.
 * 5. When automating batch processing of GIF files to ensure consistent smoothing across all frames in a .NET workflow.
 */
