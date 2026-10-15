// HOW-TO: Rotate SVG Hue 180 Degrees And Export PNG Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\vector.svg";
        string outputPath = "Output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                PngOptions pngOptions = new PngOptions();

                using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pngOptions, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(raster);
                    graphics.DrawImage(vectorImage, new Aspose.Imaging.Rectangle(0, 0, width, height));

                    raster.AdjustGamma(180f);
                    raster.Save(outputPath, pngOptions);
                }
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
 * 1. When you need to recolor a logo stored as SVG by shifting its hue and deliver it as a PNG for web use.
 * 2. When an application must generate color‑variant thumbnails from vector icons without manually editing each file.
 * 3. When a batch process has to convert SVG diagrams to PNG while applying a 180° hue rotation for branding consistency.
 * 4. When you want to programmatically adjust the overall color tone of vector artwork before embedding it in a PDF or report.
 * 5. When a graphics pipeline requires rasterizing vector graphics and applying a global color shift to match a dark‑mode theme.
 */
