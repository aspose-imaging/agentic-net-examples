// HOW-TO: Convert JPEG to WebP with Quality 75 Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                WebPOptions options = new WebPOptions
                {
                    Quality = 75
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
 * 1. When you need to reduce page load time by converting high‑resolution JPEG photos to smaller WebP files with a controlled quality level.
 * 2. When preparing image assets for a mobile app that requires WebP format with lossless alpha support while keeping visual fidelity at 75 % quality.
 * 3. When migrating a legacy photo gallery to modern web standards and want to automate JPEG‑to‑WebP conversion in a C# backend.
 * 4. When generating thumbnails for an e‑commerce site and need consistent compression settings to balance size and quality.
 * 5. When integrating Aspose.Imaging into a CI pipeline to batch‑process uploaded JPEGs into WebP for CDN distribution.
 */
