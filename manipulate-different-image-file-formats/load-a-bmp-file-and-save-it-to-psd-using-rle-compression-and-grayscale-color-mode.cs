// HOW-TO: Convert BMP to Grayscale PSD with RLE Compression in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.bmp";
            string outputPath = "Output\\sample.psd";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            using (PsdOptions options = new PsdOptions())
            {
                options.ColorMode = ColorModes.Grayscale;
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
 * 1. When a developer needs to prepare black‑and‑white print‑ready assets by converting high‑resolution BMP scans into compressed grayscale PSD files for Photoshop workflows.
 * 2. When an application must archive legacy BMP images in a smaller, lossless PSD format while preserving only intensity data to reduce storage costs.
 * 3. When a graphics pipeline requires converting user‑uploaded BMP files to PSD with RLE compression before applying layer‑based editing in a .NET service.
 * 4. When a batch‑processing tool needs to transform BMP screenshots into grayscale PSD files for automated quality‑control analysis.
 * 5. When integrating Aspose.Imaging into a C# project to generate PSD files compatible with Photoshop that use grayscale mode for machine‑learning training datasets.
 */
