// HOW-TO: Blend PNG Overlay Onto JPEG Background Using Multiply Mode In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string backgroundPath = "background.jpg";
            string overlayPath = "overlay.png";
            string outputPath = "output/result.png";

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
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                int posX = (background.Width - overlay.Width) / 2;
                int posY = (background.Height - overlay.Height) / 2;
                Aspose.Imaging.Point position = new Aspose.Imaging.Point(posX, posY);

                var blendOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ImageBlendingFilterOptions()
                {
                    Image = overlay,
                    Position = position,
                    Opacity = 127,
                    BlendingMode = Aspose.Imaging.ImageFilters.FilterOptions.BlendingMode.Multiply
                };

                background.Filter(background.Bounds, blendOptions);

                PngOptions pngOptions = new PngOptions()
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                background.Save(outputPath, pngOptions);
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
 * 1. When you need to place a semi‑transparent PNG logo onto a JPEG product photo and preserve the dark tones by using the Multiply blending mode in C#.
 * 2. When you want to create a watermark that darkens the underlying JPEG image without altering its colors by blending a PNG overlay with opacity.
 * 3. When generating marketing banners that require a centered PNG graphic on a high‑resolution JPEG background and saving the result as a lossless PNG file.
 * 4. When building an automated pipeline that combines user‑uploaded PNG stickers with JPEG backgrounds for social‑media posts using Aspose.Imaging’s ImageBlendingFilterOptions.
 * 5. When preparing print‑ready assets where the overlay must interact with the background using Multiply blending to enhance contrast before exporting to PNG.
 */
