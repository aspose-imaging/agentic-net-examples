// HOW-TO: Convert CMX File To 8‑Bit TIFF Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cmx";
            string outputPath = "Output/sample.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    tiffOptions.BitsPerSample = new ushort[] { 8 };
                    tiffOptions.Photometric = TiffPhotometrics.MinIsWhite;
                    image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to archive legacy CorelDRAW CMX drawings as lossless 8‑bit TIFF files for long‑term storage.
 * 2. When converting CMX artwork to a format compatible with printing workflows that require 8‑bit grayscale TIFF images.
 * 3. When generating TIFF thumbnails from CMX files for a web gallery that only supports TIFF with a single 8‑bit channel.
 * 4. When integrating a document management system that stores all images as 8‑bit TIFF and must import existing CMX files.
 * 5. When automating batch conversion of CMX designs to TIFF to meet regulatory standards that mandate 8‑bit per sample images.
 */
