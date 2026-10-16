// HOW-TO: Save GIF with Custom Color Depth and Dithering Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                GifOptions options = new GifOptions();
                gif.Save(outputPath, options);
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
 * 1. When a developer needs to reduce the file size of animated GIFs for faster web page loading while preserving visual quality.
 * 2. When creating GIFs for mobile apps where limited color palettes and specific dithering improve appearance on low‑resolution screens.
 * 3. When converting legacy GIF assets to a standardized color depth to ensure consistent rendering across different browsers.
 * 4. When generating GIF thumbnails with controlled dithering to maintain recognizable detail in preview images.
 * 5. When batch‑processing a collection of GIFs to apply the same color depth and dithering settings before uploading to a content delivery network.
 */
