// HOW-TO: Blend Overlay Image onto Base PNG with 70% Opacity in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseImagePath = "base.png";
            string overlayImagePath = "overlay.png";
            string outputImagePath = "output.png";

            if (!File.Exists(baseImagePath))
            {
                Console.Error.WriteLine($"File not found: {baseImagePath}");
                return;
            }
            if (!File.Exists(overlayImagePath))
            {
                Console.Error.WriteLine($"File not found: {overlayImagePath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputImagePath) ?? ".";
            Directory.CreateDirectory(outputDir);

            using (RasterImage baseImage = (RasterImage)Image.Load(baseImagePath))
            using (RasterImage overlayImage = (RasterImage)Image.Load(overlayImagePath))
            {
                var blendOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ImageBlendingFilterOptions();
                blendOptions.Image = overlayImage;
                blendOptions.Position = new Point(50, 30);
                blendOptions.Opacity = 178; // 70% of 255

                baseImage.Filter(baseImage.Bounds, blendOptions);

                Source outputSource = new FileCreateSource(outputImagePath, false);
                PngOptions pngOptions = new PngOptions() { Source = outputSource };
                baseImage.Save(outputImagePath, pngOptions);
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
 * 1. When you need to watermark a product photo with a semi‑transparent logo before publishing it online.
 * 2. When generating custom thumbnails that combine a background image with a badge at a specific offset.
 * 3. When creating promotional graphics that overlay a discount banner onto existing banner images with controlled transparency.
 * 4. When automating the preparation of UI assets by compositing a UI element onto a base screenshot at a fixed position.
 * 5. When building a batch process that merges a transparent PNG overlay onto multiple base images for brand consistency.
 */
