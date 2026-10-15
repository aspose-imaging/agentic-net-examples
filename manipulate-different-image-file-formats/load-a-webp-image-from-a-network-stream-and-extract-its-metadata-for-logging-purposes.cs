// HOW-TO: Read WebP Image Metadata and Save to Text File in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.webp";
            string outputPath = "output\\metadata.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                bool isWebP = image is WebPImage;
                string metadata = "=== WebP Image Metadata ===\n";
                metadata += $"Width: {image.Width}\n";
                metadata += $"Height: {image.Height}\n";
                metadata += $"Bits Per Pixel: {image.BitsPerPixel}\n";
                metadata += $"Is WebP Image: {(isWebP ? "Yes" : "No")}\n";
                metadata += $"File Format: {image.FileFormat}\n";

                Console.WriteLine(metadata);
                File.WriteAllText(outputPath, metadata);
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
 * 1. When you need to log the dimensions and format of WebP images received from a web service for audit trails.
 * 2. When you want to verify that a file is a valid WebP image before processing it in an image conversion pipeline.
 * 3. When you are building a diagnostic tool that extracts pixel depth and other properties from user‑uploaded WebP files.
 * 4. When you need to generate a simple text report of WebP image characteristics to include in automated test results.
 * 5. When you are troubleshooting image rendering issues and require a quick way to dump WebP metadata to a log file.
 */
