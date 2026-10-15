// HOW-TO: Check PNG Transparency After Converting TIFF to PNG in C# (Aspose.Imaging for .NET)
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
        try
        {
            string tiffPath = "Input/source.tif";
            string pngPath = "Output/result.png";

            if (!File.Exists(tiffPath))
            {
                Console.Error.WriteLine($"File not found: {tiffPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

            using (Image tiffImage = Image.Load(tiffPath))
            {
                using (PngOptions pngOptions = new PngOptions { Source = new FileCreateSource(pngPath, false) })
                {
                    tiffImage.Save(pngPath, pngOptions);
                }
            }

            using (RasterImage pngImage = (RasterImage)Image.Load(pngPath))
            {
                int[] pixels = pngImage.LoadArgb32Pixels(pngImage.Bounds);
                bool hasAlpha = false;
                foreach (int pixel in pixels)
                {
                    int alpha = (pixel >> 24) & 0xFF;
                    if (alpha != 255)
                    {
                        hasAlpha = true;
                        break;
                    }
                }
                Console.WriteLine(hasAlpha ? "PNG has transparency." : "PNG is fully opaque.");
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
 * 1. When you need to verify whether a PNG generated from a TIFF contains any transparent pixels before displaying it on a website.
 * 2. When you want to ensure that images converted for PDF creation remain fully opaque to prevent rendering artifacts.
 * 3. When an automated batch job must log the transparency status of exported PNGs to decide if additional compositing steps are required.
 * 4. When integrating a legacy TIFF asset pipeline and you must detect transparency to apply the correct background handling.
 * 5. When performing quality checks on exported PNGs to confirm they comply with branding guidelines that forbid semi‑transparent graphics.
 */
