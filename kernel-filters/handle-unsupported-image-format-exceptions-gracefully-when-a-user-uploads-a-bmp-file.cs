// HOW-TO: Convert BMP to PNG in C# With Aspose.Imaging and Error Handling (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.bmp");
            string outputPath = Path.Combine("Output", "sample_converted.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
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
 * 1. When a web application receives user‑uploaded BMP files and must convert them to PNG for browser compatibility while safely handling unsupported format errors.
 * 2. When a desktop utility processes a batch of legacy BMP images, converting each to PNG and ensuring the program logs any loading failures without crashing.
 * 3. When an automated image pipeline needs to transform BMP assets to lossless PNGs before storage, with graceful exception handling for corrupted or missing files.
 * 4. When integrating Aspose.Imaging into a C# service that validates incoming image types, converting valid BMPs to PNG and returning clear error messages for unsupported formats.
 * 5. When building a file‑conversion API that accepts BMP uploads, saves them as PNG using Aspose.Imaging, and provides robust error reporting for file‑not‑found or format issues.
 */
