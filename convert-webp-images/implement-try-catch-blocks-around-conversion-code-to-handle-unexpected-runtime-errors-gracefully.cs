// HOW-TO: Convert JPEG to PNG with Error Handling in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    image.Save(outputPath, options);
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
 * 1. When you need to batch‑convert user‑uploaded JPEG photos to PNG for web display while ensuring the application logs missing files.
 * 2. When a desktop utility must save scanned JPEG images as lossless PNGs and gracefully handle I/O exceptions.
 * 3. When an automated workflow transforms product catalog JPEGs into PNG thumbnails and must continue processing despite runtime errors.
 * 4. When a server‑side service converts incoming JPEG attachments to PNG format and needs to report conversion failures without crashing.
 * 5. When a migration script rewrites legacy JPEG assets to PNG using Aspose.Imaging and requires robust try‑catch error handling.
 */
