// HOW-TO: Convert BMP to JPEG2000 and Get Output File Size in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\source.bmp";
            string outputPath = "Output\\result.jp2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image bmp = Image.Load(inputPath))
            {
                var jp2Options = new Jpeg2000Options();
                bmp.Save(outputPath, jp2Options);
            }

            long fileSize = new FileInfo(outputPath).Length;
            Console.WriteLine($"Output file size: {fileSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compress a high‑resolution BMP into a smaller JPEG2000 file for web delivery while preserving image quality.
 * 2. When integrating Aspose.Imaging into a batch conversion tool that transforms legacy BMP assets to JPEG2000 for archival storage.
 * 3. When developing a C# application that must report the exact size of the generated JPEG2000 image to enforce size limits or quotas.
 * 4. When creating a workflow that converts scanned BMP documents to JPEG2000 to take advantage of lossless compression before further processing.
 * 5. When troubleshooting image conversion pipelines and need a simple code snippet to load a BMP, save as JPEG2000, and log the resulting file size for diagnostics.
 */
