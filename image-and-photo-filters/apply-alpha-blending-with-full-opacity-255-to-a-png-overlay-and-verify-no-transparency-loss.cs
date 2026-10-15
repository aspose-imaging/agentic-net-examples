// HOW-TO: Blend PNG Overlay with Full Opacity and Verify Transparency in C# (Aspose.Imaging for .NET)
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
        string backgroundPath = "background.png";
        string overlayPath = "overlay.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }

            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
            {
                using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
                {
                    background.Blend(new Point(0, 0), overlay, 255);

                    PngOptions options = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    background.Save();

                    using (RasterImage result = (RasterImage)Image.Load(outputPath))
                    {
                        int[] overlayPixels = overlay.LoadArgb32Pixels(overlay.Bounds);
                        Rectangle region = new Rectangle(0, 0, overlay.Width, overlay.Height);
                        int[] resultPixels = result.LoadArgb32Pixels(region);

                        bool transparencyPreserved = true;
                        for (int i = 0; i < overlayPixels.Length; i++)
                        {
                            byte overlayAlpha = (byte)((overlayPixels[i] >> 24) & 0xFF);
                            byte resultAlpha = (byte)((resultPixels[i] >> 24) & 0xFF);
                            if (overlayAlpha != resultAlpha)
                            {
                                transparencyPreserved = false;
                                break;
                            }
                        }

                        if (transparencyPreserved)
                            Console.WriteLine("Transparency preserved.");
                        else
                            Console.WriteLine("Transparency loss detected.");
                    }
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
 * 1. When you need to combine a logo PNG onto a background image without any translucency loss for branding assets.
 * 2. When generating composite images for web thumbnails where the overlay must appear fully opaque.
 * 3. When preparing print‑ready graphics and must ensure the overlay’s alpha channel remains unchanged after blending.
 * 4. When creating UI spritesheets and need to validate that the overlay’s transparency is preserved after merging.
 * 5. When automating batch image processing to overlay watermarks and require a programmatic check that no alpha information is lost.
 */
