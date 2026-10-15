// HOW-TO: Remove Background From EMF and Save As 300 DPI PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var vectorImage = image as VectorImage;
                if (vectorImage != null)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }

                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = image.Size
                    }
                };

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
 * 1. When you need to convert vector EMF logos into high‑resolution PNGs with transparent backgrounds for web or print assets.
 * 2. When preparing diagram images for inclusion in PDF reports that require 300 DPI rasterization and no background color.
 * 3. When automating the cleanup of legacy EMF drawings so the resulting PNG can be layered over other graphics without a white box.
 * 4. When generating thumbnails of EMF icons at print quality while preserving alpha transparency for UI design.
 * 5. When integrating a batch process that strips backgrounds from EMF files before uploading them to a content‑management system that only accepts PNG images.
 */
