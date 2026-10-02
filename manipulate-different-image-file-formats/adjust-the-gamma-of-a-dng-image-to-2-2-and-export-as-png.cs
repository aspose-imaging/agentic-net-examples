// HOW-TO: Adjust Gamma of DNG Image to 2.2 and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dng";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                dng.AdjustGamma(2.2f);
                PngOptions pngOptions = new PngOptions();
                dng.Save(outputPath, pngOptions);
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
 * 1. When you need to correct the brightness of a raw DNG photo for web display by applying a standard 2.2 gamma curve before converting it to PNG.
 * 2. When building an automated pipeline that ingests raw camera files and outputs gamma‑corrected PNGs for downstream image analysis.
 * 3. When a mobile app requires low‑size PNG assets derived from DNG files with consistent gamma for accurate color rendering.
 * 4. When integrating a digital asset management system that must normalize raw images to a common gamma before archiving them as PNG thumbnails.
 * 5. When performing batch processing of scientific images captured in DNG format and needing to apply gamma correction to meet publication standards before exporting to PNG.
 */
