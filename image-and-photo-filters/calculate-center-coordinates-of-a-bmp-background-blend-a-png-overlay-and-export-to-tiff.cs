// HOW-TO: Center PNG Overlay On BMP Background And Save As TIFF In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string backgroundPath = "background.bmp";
            string overlayPath = "overlay.png";
            string outputPath = "output/result.tiff";

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
                int x = (background.Width - overlay.Width) / 2;
                int y = (background.Height - overlay.Height) / 2;
                Point location = new Point(x, y);
                background.Blend(location, overlay, 255);

                Source source = new FileCreateSource(outputPath, false);
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default) { Source = source })
                {
                    background.Save(outputPath, tiffOptions);
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
 * 1. When you need to place a logo PNG exactly in the middle of a BMP template and output the combined image as a high‑resolution TIFF for printing.
 * 2. When generating product catalogs where a transparent PNG badge must be centered over a bitmap background before saving to TIFF for archival.
 * 3. When creating watermarked TIFF files by blending a PNG watermark at the center of an existing BMP image.
 * 4. When automating the preparation of scanned documents by adding a centered PNG stamp to BMP scans and exporting them to TIFF for compliance.
 * 5. When developing a .NET service that merges a PNG overlay with a BMP canvas and stores the result in TIFF format for downstream image analysis.
 */
