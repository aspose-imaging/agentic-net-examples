// HOW-TO: Convert BMP to JPEG2000 with Lossless Compression in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "source.bmp");
            string outputPath = Path.Combine("Output", "result.jp2");

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
 * 1. When you need to archive high‑resolution bitmap graphics without quality loss by converting them to JPEG2000 files in a .NET application.
 * 2. When a medical imaging system requires lossless JPEG2000 output from BMP scans for DICOM compliance using C#.
 * 3. When a digital publishing workflow must reduce file size of source BMP assets while preserving exact pixel data for print‑ready PDFs.
 * 4. When a GIS application converts raster map tiles stored as BMP into JPEG2000 to enable efficient storage and fast retrieval.
 * 5. When an e‑learning platform generates lossless JPEG2000 thumbnails from BMP diagrams to ensure crisp visuals across devices.
 */
