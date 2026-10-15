// HOW-TO: Resize SVG to 300x300 PNG with Lanczos Resampling in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.svg";
            string outputPath = "output\\resized.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Resize(300, 300, ResizeType.LanczosResample);
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate thumbnail previews of scalable SVG icons for a web gallery, converting them to 300 × 300 PNGs with high‑quality Lanczos resampling.
 * 2. When an e‑commerce platform requires product vector logos to be displayed as fixed‑size PNG images on mobile devices.
 * 3. When a reporting tool must embed SVG diagrams as raster images in PDF reports that only support PNG format.
 * 4. When a content management system automatically creates uniformly sized preview images from uploaded SVG files for faster page loading.
 * 5. When a game UI pipeline converts vector assets into 300 × 300 PNG sprites while preserving detail using Lanczos resampling.
 */
