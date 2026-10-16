// HOW-TO: Rotate CMX Image 90 Degrees and Convert to TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "sample.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                cmx.RotateFlip(RotateFlipType.Rotate90FlipNone);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                cmx.Save(outputPath, tiffOptions);
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
 * 1. When a legacy CMX drawing is stored upside‑down and must be reoriented before archiving as a TIFF file.
 * 2. When an automated pipeline processes CAD files and needs to ensure all exported TIFF pages have a consistent portrait orientation.
 * 3. When a printing service requires CMX artwork rotated 90° to match the press layout before converting to high‑resolution TIFF.
 * 4. When a document management system imports CMX files and must rotate them to display correctly in thumbnail previews saved as TIFF.
 * 5. When a batch conversion tool needs to apply a specific rotation to each CMX image before saving them as TIFF for compatibility with downstream .NET image libraries.
 */
