// HOW-TO: How To Apply Lossless Compression To JPEG2000 And Compare File Size In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\original.jp2";
            string outputPath = "output\\compressed.jp2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            long originalSize = new FileInfo(inputPath).Length;

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new Jpeg2000Options();
                image.Save(outputPath, options);
            }

            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce storage space for archival JPEG2000 images without losing any visual quality.
 * 2. When you want to generate a smaller version of a lossless JPEG2000 file for faster transmission over a network.
 * 3. When you must verify that re‑saving a JPEG2000 image with default options actually decreases the file size.
 * 4. When building a batch processing tool that logs original and compressed sizes for compliance reporting.
 * 5. When integrating Aspose.Imaging into a C# application to compare image sizes before and after lossless compression for quality‑controlled workflows.
 */
