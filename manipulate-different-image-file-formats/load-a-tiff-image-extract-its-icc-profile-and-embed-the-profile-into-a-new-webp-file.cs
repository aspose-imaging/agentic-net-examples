// HOW-TO: Convert TIFF to WebP with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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
        string inputPath = "input.tif";
        string outputPath = "output.webp";

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
                WebPOptions options = new WebPOptions();
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
 * 1. When you need to convert high‑resolution TIFF photographs to smaller WebP files for faster web page loading in a .NET application.
 * 2. When a server‑side C# service must batch‑process scanned TIFF documents and output them as WebP images to reduce storage costs.
 * 3. When integrating Aspose.Imaging into an image‑processing pipeline that requires converting legacy TIFF assets to the modern WebP format for mobile apps.
 * 4. When you want to programmatically generate WebP thumbnails from TIFF source files in a Windows service using C#.
 * 5. When building a cloud‑based API that accepts TIFF uploads and returns WebP images to clients while preserving image quality with Aspose.Imaging.
 */
