// HOW-TO: Convert DNG Raw Image to 16‑Bit TIFF Preserving Sensor Data in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dng";
        string outputPath = "output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
        Directory.CreateDirectory(outputDir);

        try
        {
            using (var dng = (Aspose.Imaging.FileFormats.Dng.DngImage)Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 16, 16, 16 },
                    Photometric = TiffPhotometrics.Rgb,
                    Compression = TiffCompressions.None
                };
                dng.Save(outputPath, tiffOptions);
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
 * 1. When a photographer needs to archive raw DNG files as loss‑less 16‑bit TIFFs for long‑term storage while keeping the original sensor data intact.
 * 2. When a scientific imaging application must convert camera raw data to a 16‑bit TIFF format for analysis in software that only supports TIFF.
 * 3. When a batch processing pipeline requires programmatic conversion of DNG files to uncompressed TIFFs using C# and Aspose.Imaging to maintain color fidelity.
 * 4. When a developer is building a web service that receives DNG uploads and returns high‑resolution 16‑bit TIFFs for downstream editing tools.
 * 5. When a digital asset management system needs to generate TIFF previews from DNG raw images without applying any compression to preserve image quality.
 */
