// HOW-TO: Convert OTG to BMP with 150 DPI Resolution in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                BmpOptions options = new BmpOptions();
                options.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(150, 150);
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
 * 1. When you need to generate high‑resolution BMP thumbnails from OTG design files for printing workflows.
 * 2. When a legacy system only accepts BMP images and you must preserve the original 150 DPI setting from an OTG source.
 * 3. When automating batch conversion of OTG graphics to BMP for inclusion in a .NET desktop application that requires a specific DPI.
 * 4. When preparing OTG artwork for DPI‑sensitive devices such as scanners or plotters that expect BMP input at 150 DPI.
 * 5. When integrating Aspose.Imaging into a C# service that converts user‑uploaded OTG files to BMP while maintaining a custom resolution for accurate size calculations.
 */
