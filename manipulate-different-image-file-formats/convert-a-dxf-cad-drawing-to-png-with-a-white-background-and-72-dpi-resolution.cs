// HOW-TO: Convert DXF CAD Drawing to PNG with White Background at 72 DPI in C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input\\drawing.dxf";
        string outputPath = "Output\\drawing.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Source source = new FileCreateSource(outputPath, false);
                PngOptions options = new PngOptions
                {
                    Source = source,
                    ResolutionSettings = new ResolutionSetting(72, 72),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };
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
 * 1. When you need to generate preview thumbnails of engineering DXF files for a web portal, converting them to PNG with a uniform white background and 72 DPI.
 * 2. When an automated reporting system must embed CAD drawings into PDF reports, you can first rasterize the DXF to a 72 DPI PNG to ensure consistent sizing and background.
 * 3. When a mobile app displays architectural plans, converting the DXF to a low‑resolution PNG with a white background reduces file size and improves rendering speed.
 * 4. When batch‑processing a library of CAD drawings for archival, you can use this code to standardize all files to PNG format with the same resolution and background color.
 * 5. When integrating CAD data into a GIS mapping application, rasterizing the DXF to a 72 DPI PNG with a white background ensures the image aligns correctly with other map layers.
 */
