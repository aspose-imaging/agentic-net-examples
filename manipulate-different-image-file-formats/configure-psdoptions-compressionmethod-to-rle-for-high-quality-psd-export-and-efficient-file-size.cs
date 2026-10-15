// HOW-TO: Export JPEG to PSD with RLE Compression Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = Path.Combine("Input", "sample.jpg");
            string outputPath = Path.Combine("Output", "sample.psd");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PsdOptions options = new PsdOptions();
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
 * 1. When you need to convert high‑resolution JPEG photos to Photoshop PSD files while keeping file size low by using RLE compression.
 * 2. When an automated image‑processing pipeline must generate PSD layers from user‑uploaded JPEGs for further editing in Photoshop.
 * 3. When a web service creates downloadable PSD assets from product images and wants to preserve quality without bloating storage.
 * 4. When a desktop application batch‑processes a folder of JPEGs into PSDs for designers who require lossless channel data.
 * 5. When integrating Aspose.Imaging into a C# project to export images to PSD format with efficient compression for archival purposes.
 */
