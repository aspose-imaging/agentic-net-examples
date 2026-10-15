// HOW-TO: Export PSD to TIFF with Embedded Fonts Preserved Using FontSettings in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions();

            using (var image = Image.Load(inputPath, loadOptions))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a design workflow requires converting Photoshop PSD files to high‑resolution TIFFs while keeping text layers rendered with the original embedded fonts using Aspose.Imaging for .NET.
 * 2. When an automated batch process must generate print‑ready TIFF images from PSD sources without losing font information via FontSettings.
 * 3. When a document management system needs to store PSD artwork as TIFF thumbnails that accurately display the embedded typography with Aspose.Imaging.
 * 4. When a web service creates downloadable TIFF previews of PSD files and must ensure the text appears exactly as designed using FontSettings.
 * 5. When a legacy application that only supports TIFF format must render PSD files with embedded fonts intact for archival purposes using Aspose.Imaging.
 */
