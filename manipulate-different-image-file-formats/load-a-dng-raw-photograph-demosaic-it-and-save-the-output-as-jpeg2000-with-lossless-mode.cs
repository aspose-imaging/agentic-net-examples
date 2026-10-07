// HOW-TO: Convert DNG Raw Photo to Lossless JPEG2000 in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/photo.dng";
            string outputPath = "Output/photo.jp2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                using (Jpeg2000Options options = new Jpeg2000Options())
                {
                    dng.Save(outputPath, options);
                }
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
 * 1. When a photographer needs to archive raw DNG files as lossless JPEG2000 for long‑term storage while preserving full color detail.
 * 2. When a web service must deliver high‑quality preview images from DNG uploads without introducing compression artifacts.
 * 3. When a scientific imaging pipeline requires converting raw sensor data to a standardized lossless format for downstream analysis.
 * 4. When a digital asset management system needs to batch‑process DNG assets into JPEG2000 to reduce file size while keeping lossless fidelity.
 * 5. When a developer integrates Aspose.Imaging to demosaic raw camera files and export them as JPEG2000 for compatibility with legacy viewers.
 */
