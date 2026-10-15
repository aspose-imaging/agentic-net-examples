// HOW-TO: Rotate PNG 90 Degrees, Blend Transparent Overlay, Save as GIF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string overlayPath = "overlay.png";
        string outputPath = "output/output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage baseImage = (RasterImage)Image.Load(inputPath))
            {
                if (!baseImage.IsCached)
                    baseImage.CacheData();

                baseImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
                {
                    if (!overlay.IsCached)
                        overlay.CacheData();

                    baseImage.Blend(new Point(0, 0), overlay, 128);
                }

                GifOptions gifOptions = new GifOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                baseImage.Save(outputPath, gifOptions);
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
 * 1. When you need to rotate a product photo 90° and add a semi‑transparent watermark before publishing it as an animated GIF for a web carousel.
 * 2. When you want to combine a base PNG map with a translucent overlay of traffic data, rotate it for correct orientation, and output the result as a GIF for low‑bandwidth distribution.
 * 3. When you are generating game sprites that require a 90° rotation and a semi‑transparent effect layer, then saving them as GIFs for use in legacy browsers.
 * 4. When you must process user‑uploaded PNG images, apply a rotated logo overlay with 50% opacity, and store the final image as a GIF for email attachments.
 * 5. When you are creating promotional banners that need a rotated background PNG, a translucent promotional badge, and a GIF output to ensure compatibility with older email clients.
 */
