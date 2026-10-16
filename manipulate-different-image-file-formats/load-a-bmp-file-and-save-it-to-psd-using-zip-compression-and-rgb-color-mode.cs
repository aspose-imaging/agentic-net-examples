// HOW-TO: Convert BMP to PSD with RLE Compression and RGB Mode in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.bmp";
        string outputPath = "Output\\sample.psd";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Rgb
                };

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
 * 1. When you need to import legacy BMP assets into a Photoshop workflow while preserving lossless RLE compression and RGB color fidelity using C#.
 * 2. When automating batch conversion of bitmap images to PSD files for a design pipeline that requires specific color mode settings.
 * 3. When building a server‑side service that receives BMP uploads and returns PSD files optimized with RLE compression for downstream editing.
 * 4. When migrating image assets from a Windows application to a cross‑platform graphics editor that only accepts PSD format with RGB mode.
 * 5. When creating a backup of BMP graphics in a layered PSD container to enable future editing without quality loss.
 */
