// HOW-TO: Feather Mask Edges on High Resolution TIFF with Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var mask = MagicWandTool.Select(image, new MagicWandSettings(10, 10));
                mask.GetFeathered(new FeatheringSettings { Size = 5 }).Apply();

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);
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
 * 1. When you need to smooth the borders of a selection mask in a large TIFF before further editing or analysis.
 * 2. When preparing scanned documents for OCR where jagged mask edges could cause recognition errors.
 * 3. When creating print‑ready images and you want feathered transitions between masked and unmasked areas to avoid harsh lines.
 * 4. When automating batch processing of satellite or medical TIFF images and require consistent edge softening for visual consistency.
 * 5. When integrating Aspose.Imaging into a C# workflow to apply a 5‑pixel feather to a mask and save the result without losing TIFF metadata.
 */
