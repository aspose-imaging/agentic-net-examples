// HOW-TO: Resize PNG to 800x600 and Save as Lossless WebP in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Resize(800, 600);
                WebPOptions options = new WebPOptions
                {
                    Lossless = true
                };
                image.Save(outputPath, options);
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
 * 1. When a web developer needs to generate smaller, web‑optimized PNG thumbnails that retain full quality by converting them to lossless WebP for faster page loads.
 * 2. When an e‑commerce platform must batch‑process product photos, resizing each PNG to a standard 800×600 size and storing them as lossless WebP to reduce storage costs while preserving detail.
 * 3. When a mobile app prepares user‑uploaded PNG avatars, resizing them to fit UI constraints and saving them as lossless WebP to minimize bandwidth usage without quality loss.
 * 4. When a digital asset management system migrates legacy PNG graphics to a modern format, automatically resizing and converting them to lossless WebP for consistent delivery across browsers.
 * 5. When a content management system creates responsive images, resizing original PNGs to 800×600 and saving them as lossless WebP to ensure crisp visuals on high‑resolution displays.
 */
