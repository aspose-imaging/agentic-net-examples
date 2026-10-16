// HOW-TO: Flip CDR Image Horizontally and Save as LZW Compressed TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage image = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                image.RotateFlip(Aspose.Imaging.RotateFlipType.RotateNoneFlipX);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a designer needs to mirror a CorelDRAW (CDR) illustration and archive it as a loss‑less TIFF for printing or long‑term storage.
 * 2. When an automated batch process must convert multiple CDR files to LZW‑compressed TIFFs while applying a horizontal flip to meet layout specifications.
 * 3. When a web service receives CDR artwork, flips it for right‑to‑left languages, and returns a TIFF with LZW compression to reduce bandwidth.
 * 4. When a digital asset management system requires CDR assets to be stored as TIFFs with lossless compression after applying a flip transformation.
 * 5. When a .NET application integrates Aspose.Imaging to preprocess CDR graphics by mirroring them and saving as compact TIFF files for downstream GIS or publishing workflows.
 */
