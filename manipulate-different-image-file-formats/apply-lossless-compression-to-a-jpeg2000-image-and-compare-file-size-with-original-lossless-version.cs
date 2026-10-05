// HOW-TO: Apply Lossless Compression to JPEG2000 and Compare File Size in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jp2";
            string outputPath = "Output\\output_lossless.jp2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Jpeg2000Options options = new Jpeg2000Options();
                image.Save(outputPath, options);
            }

            long originalSize = new FileInfo(inputPath).Length;
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
 * 1. When you need to reduce the storage size of high‑resolution JPEG2000 scans without losing any image data, such as archiving medical images.
 * 2. When you want to compare the effectiveness of Aspose.Imaging’s lossless JPEG2000 compression against the original file to decide if re‑encoding is worthwhile.
 * 3. When building a C# batch‑processing tool that standardizes JPEG2000 files to a consistent lossless format for digital asset management.
 * 4. When optimizing image delivery for bandwidth‑limited environments while preserving exact pixel fidelity, like in satellite imagery pipelines.
 * 5. When validating that a newly generated JPEG2000 file meets size constraints for regulatory compliance in document imaging systems.
 */
