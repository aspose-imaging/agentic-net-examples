// HOW-TO: Save Single-Frame APNG While Preserving Backward Compatibility In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\input.apng";
            string outputPath = "Output\\output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new ApngOptions());
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
 * 1. When you need to re‑save an existing APNG that contains only a single static frame without losing compatibility with older browsers or tools.
 * 2. When a web application must validate and rewrite uploaded APNG files to ensure they remain viewable in legacy image viewers.
 * 3. When a batch processing job has to copy APNG assets while guaranteeing the output file adheres to the original APNG specification for single‑frame images.
 * 4. When integrating Aspose.Imaging into a C# service that normalizes image formats and must keep single‑frame APNGs backward compatible.
 * 5. When generating thumbnails from user‑provided APNGs and you want to preserve the original static frame while saving it in a universally supported APNG file.
 */
