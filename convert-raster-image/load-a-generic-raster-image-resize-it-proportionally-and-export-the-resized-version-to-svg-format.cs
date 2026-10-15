// HOW-TO: Resize JPEG Image to Half Size and Save as SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                if (!raster.IsCached)
                    raster.CacheData();

                int newWidth = raster.Width / 2;
                int newHeight = raster.Height / 2;

                raster.Resize(newWidth, newHeight, Aspose.Imaging.ResizeType.LanczosResample);

                raster.Save(outputPath, new SvgOptions());
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
 * 1. When you need to generate a lightweight SVG thumbnail from a high‑resolution JPEG for responsive web pages.
 * 2. When converting scanned photos into scalable vector graphics while reducing dimensions to improve loading speed in mobile apps.
 * 3. When preparing print‑ready artwork by shrinking raster assets and exporting them as SVG for vector‑based layout tools.
 * 4. When automating batch processing to create half‑size SVG versions of product images for e‑commerce catalogs.
 * 5. When integrating Aspose.Imaging in a C# service that must cache large raster files, resize them, and deliver SVG output to downstream APIs.
 */
