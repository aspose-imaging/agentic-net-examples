// HOW-TO: Convert BMP to JPEG2000 with Lossless Compression in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\source.bmp";
            string outputPath = "Output\\result.jp2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new Jpeg2000Options();
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
 * 1. When you need to archive high‑resolution bitmap graphics without quality loss by converting them to JPEG2000 in a .NET application.
 * 2. When a medical imaging system requires lossless JPEG2000 files generated from BMP scans for regulatory compliance.
 * 3. When a web service must deliver large satellite images in a compact, lossless format to reduce bandwidth while preserving detail.
 * 4. When a document management workflow converts scanned BMP pages to JPEG2000 to enable efficient storage and later retrieval.
 * 5. When a digital preservation project needs to batch‑process BMP assets into JPEG2000 using C# to maintain original pixel fidelity.
 */
