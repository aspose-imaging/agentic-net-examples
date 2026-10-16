// HOW-TO: Set PSD Resolution to 300 DPI When Converting JPEG in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions();
                psdOptions.Source = new FileCreateSource(outputPath, false);
                psdOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                image.Save(outputPath, psdOptions);
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
 * 1. When a designer needs to export a JPEG asset as a print‑ready PSD file with 300 DPI resolution for high‑quality offset printing.
 * 2. When an e‑commerce platform generates product mockups and must ensure the PSD files meet the printer’s 300 DPI specification automatically.
 * 3. When a batch‑processing tool converts user‑uploaded photos to PSD format and must set the resolution to 300 DPI to preserve detail for large‑format prints.
 * 4. When a publishing workflow requires converting web‑optimized JPEGs to PSDs with exact DPI settings so that layout software interprets the image size correctly.
 * 5. When a digital asset management system needs to store images as PSDs with a predefined 300 DPI resolution to maintain consistency across all print‑ready assets.
 */
