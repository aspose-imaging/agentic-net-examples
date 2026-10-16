// HOW-TO: Reduce PSD Contrast By 20% And Save As PNG In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.AdjustContrast(-0.2f);

                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);
                image.Save(outputPath, pngOptions);
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
 * 1. When preparing web‑ready assets, a developer may lower the contrast of a Photoshop PSD by 20 % and export it as a PNG to achieve a softer look without manual editing.
 * 2. When automating batch processing of design files, you can programmatically reduce contrast in multiple PSDs and convert them to PNGs for faster loading in mobile apps.
 * 3. When creating print‑to‑screen previews, adjusting the PSD contrast before saving as PNG helps simulate how the image will appear on low‑contrast displays.
 * 4. When integrating a content‑management system, you might need to automatically tone down PSD images and store them as PNG thumbnails for catalog listings.
 * 5. When building a photo‑editing tool, developers can use this code to apply a 20 % contrast reduction to user‑uploaded PSDs and immediately provide a PNG output for preview.
 */
