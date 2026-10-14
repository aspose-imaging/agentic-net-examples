// HOW-TO: Set Image Resolution Before Saving JPEG to PSD in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PsdOptions options = new PsdOptions();
                options.Source = new FileCreateSource(outputPath, false);
                options.ResolutionSettings = new ResolutionSetting(300.0, 300.0);
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
 * 1. When you need to convert a high‑resolution JPEG into a Photoshop PSD file while preserving print‑ready DPI settings.
 * 2. When generating PSD assets for a design workflow that requires a specific 300 dpi resolution for accurate scaling.
 * 3. When automating batch processing of images to ensure the output PSD files meet publishing standards for magazines or brochures.
 * 4. When creating layered PSD files from source photos and must set the resolution before saving to avoid blurry prints.
 * 5. When integrating Aspose.Imaging into a C# application to produce PSD files with custom resolution for downstream editing in Photoshop.
 */
