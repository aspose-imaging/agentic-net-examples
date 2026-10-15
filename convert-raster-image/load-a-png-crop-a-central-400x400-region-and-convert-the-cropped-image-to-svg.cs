// HOW-TO: Crop Central 400x400 Region From PNG and Convert to SVG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.png";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            // Load PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for cropping
                var raster = (RasterImage)image;

                // Determine central 400x400 region
                int targetWidth = 400;
                int targetHeight = 400;
                int leftShift = (raster.Width - targetWidth) / 2;
                int rightShift = raster.Width - leftShift - targetWidth;
                int topShift = (raster.Height - targetHeight) / 2;
                int bottomShift = raster.Height - topShift - targetHeight;

                // Crop the image
                raster.Crop(leftShift, rightShift, topShift, bottomShift);

                // Save as SVG
                var svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
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
 * 1. When you need to extract a fixed‑size central thumbnail from a PNG and embed it as scalable vector graphics in a web page.
 * 2. When generating SVG icons from high‑resolution PNG assets for responsive UI designs.
 * 3. When preparing a cropped portion of a screenshot for inclusion in documentation that requires lossless scaling.
 * 4. When converting a specific area of a product image to SVG for printing or laser cutting where vector format is required.
 * 5. When automating batch processing to trim and vectorize PNG logos for branding assets.
 */
