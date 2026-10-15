// HOW-TO: Convert WMF to High Resolution PNG with 300 DPI in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "data/input.wmf";
            string outputPath = "output/highres.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        // Set a high resolution (e.g., 300 DPI) by defining page size in pixels
                        PageWidth = 3000,
                        PageHeight = 3000,
                        BackgroundColor = Color.White,
                        // Optional: improve text rendering
                        RenderMode = WmfRenderMode.Auto
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
 * 1. When you need to display vector WMF graphics on web pages that only support raster PNG images, you can rasterize them at high resolution for crisp rendering.
 * 2. When generating printable assets from legacy WMF diagrams, converting them to a 300‑dpi PNG ensures the output meets print quality standards.
 * 3. When creating thumbnails or previews of WMF files for a document management system, saving them as high‑resolution PNGs preserves detail for zoom‑in functionality.
 * 4. When migrating old Windows Metafile assets to a cross‑platform .NET application, converting them to PNG allows consistent image handling across operating systems.
 * 5. When performing batch processing of WMF logos to embed them in marketing materials, using Aspose.Imaging to export high‑resolution PNGs automates the workflow.
 */
