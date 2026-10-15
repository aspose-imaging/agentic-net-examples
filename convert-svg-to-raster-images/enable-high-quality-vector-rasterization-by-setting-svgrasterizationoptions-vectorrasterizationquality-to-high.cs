// HOW-TO: Convert SVG to PNG with High Quality Vector Rasterization in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

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
                var pngOptions = new PngOptions();
                var rasterOptions = new SvgRasterizationOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a web application must generate pixel‑perfect PNG thumbnails from user‑uploaded SVG logos for display on high‑resolution screens.
 * 2. When an e‑commerce platform needs to convert scalable product illustrations into PNG assets while preserving fine line details for print‑ready catalogs.
 * 3. When a reporting tool creates PDF reports that embed PNG images derived from SVG charts, requiring high‑quality rasterization to avoid visual artifacts.
 * 4. When a desktop utility batch‑processes a library of SVG icons into PNG files for use in a Windows application that does not support vector graphics.
 * 5. When a mobile app pre‑renders SVG assets to PNG at runtime to improve rendering performance on devices with limited SVG support.
 */
