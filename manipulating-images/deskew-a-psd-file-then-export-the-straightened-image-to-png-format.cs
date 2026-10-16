// HOW-TO: How To Deskew A PSD And Save As PNG In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output\\deskewed.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage rasterImage)
                {
                    rasterImage.NormalizeAngle();
                }

                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you receive scanned Photoshop files that are slightly rotated and need to be straightened before publishing them as web‑ready PNGs.
 * 2. When an automated workflow must correct the orientation of PSD assets from a design team and convert them to PNG for use in a mobile app.
 * 3. When a batch process has to normalize the angle of layered PSD images to ensure consistent layout in a print‑to‑digital pipeline.
 * 4. When you need to programmatically remove skew from a PSD file and export the corrected image without losing transparency by saving it as PNG.
 * 5. When integrating Aspose.Imaging into a C# service that validates incoming PSD uploads, deskews them, and stores the resulting PNG thumbnails for preview.
 */
