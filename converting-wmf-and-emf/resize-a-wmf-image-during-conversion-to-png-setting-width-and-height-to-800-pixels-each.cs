// HOW-TO: Resize WMF to 800x800 PNG During Conversion in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmf";
        string outputPath = "output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageWidth = 800,
                    PageHeight = 800
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

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
 * 1. When you need to generate thumbnail PNGs from legacy WMF icons for a web gallery, ensuring each thumbnail is exactly 800 × 800 pixels.
 * 2. When a reporting system must convert vector WMF charts into raster PNG images of a fixed size for inclusion in PDF documents.
 * 3. When an application imports user‑provided WMF drawings and must store them as uniformly sized PNG files for consistent display on mobile devices.
 * 4. When a batch‑processing job has to resize and rasterize WMF logos to 800 × 800 PNGs before uploading them to a content‑delivery network.
 * 5. When you want to programmatically enforce a maximum image dimension while converting WMF files to PNGs in a C# automation script.
 */
