// HOW-TO: Overlay PNG on SVG Converted to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string svgPath = "input.svg";
            string overlayPath = "overlay.png";
            string tempPngPath = "temp_base.png";
            string outputPath = "output.png";

            if (!File.Exists(svgPath))
            {
                Console.Error.WriteLine($"File not found: {svgPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image svgImage = Image.Load(svgPath))
            {
                PngOptions pngOptions = new PngOptions();
                svgImage.Save(tempPngPath, pngOptions);
            }

            using (RasterImage baseImg = (RasterImage)Image.Load(tempPngPath))
            using (RasterImage overlayImg = (RasterImage)Image.Load(overlayPath))
            {
                if (overlayImg.Width > baseImg.Width || overlayImg.Height > baseImg.Height)
                {
                    int newW = Math.Min(overlayImg.Width, baseImg.Width);
                    int newH = Math.Min(overlayImg.Height, baseImg.Height);
                    overlayImg.Resize(newW, newH, ResizeType.NearestNeighbourResample);
                }

                Rectangle destRect = new Rectangle(0, 0, overlayImg.Width, overlayImg.Height);
                baseImg.SaveArgb32Pixels(destRect, overlayImg.LoadArgb32Pixels(overlayImg.Bounds));

                PngOptions outOptions = new PngOptions();
                baseImg.Save(outputPath, outOptions);
            }

            if (File.Exists(tempPngPath))
            {
                try { File.Delete(tempPngPath); } catch { }
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
 * 1. When you need to add a logo or watermark PNG onto a dynamically generated SVG diagram and output a single PNG file.
 * 2. When you must combine a background illustration stored as SVG with a transparent PNG icon for a web‑app thumbnail.
 * 3. When you generate product labels in SVG and need to overlay a QR‑code PNG before publishing the final PNG image.
 * 4. When you create vector‑based UI assets in SVG and want to merge them with raster badges or icons in PNG for a composite screenshot.
 * 5. When you have an SVG map and need to place a PNG marker image on top, resizing the marker if it exceeds the map dimensions.
 */
