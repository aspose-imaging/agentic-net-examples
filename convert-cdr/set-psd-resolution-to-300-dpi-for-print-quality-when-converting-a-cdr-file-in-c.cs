// HOW-TO: Convert CDR to PSD with 300 DPI Resolution in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new PsdOptions();
                options.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300);
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
 * 1. When a designer needs to export a CorelDRAW (CDR) illustration to a Photoshop (PSD) file for high‑resolution printing, this code ensures the output is set to 300 DPI.
 * 2. When automating a batch workflow that converts multiple CDR assets to PSD for a publishing pipeline, the snippet guarantees each PSD meets print‑ready resolution standards.
 * 3. When integrating Aspose.Imaging into a C# application to generate print‑quality previews of vector graphics, setting the resolution to 300 DPI prevents loss of detail in the resulting PSD.
 * 4. When a client requires that all converted PSD files include specific DPI metadata for downstream layout software, this code programmatically applies the 300 DPI setting during conversion.
 * 5. When creating a server‑side service that receives CDR uploads and returns PSD files optimized for commercial printing, the example shows how to enforce the required 300 DPI resolution in C#.
 */
