// HOW-TO: Increase TGA DPI to 300 and Convert to TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "input.tga");
        string outputPath = Path.Combine("Output", "output.tiff");

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
                if (image is RasterImage raster)
                {
                    raster.HorizontalResolution = 300;
                    raster.VerticalResolution = 300;
                }

                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    image.Save(outputPath, tiffOptions);
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
 * 1. When preparing game textures for high‑resolution printing, you need to raise a 72 DPI TGA file to 300 DPI and save it as a TIFF for lossless output.
 * 2. When migrating legacy assets from a graphics pipeline, you may need to convert low‑resolution TGA images to high‑resolution TIFFs to meet publishing standards.
 * 3. When creating archival copies of technical drawings stored as TGA, increasing the DPI and converting to TIFF ensures the files retain detail for future reference.
 * 4. When integrating TGA sprites into a CAD workflow, you must adjust the image resolution to 300 DPI and export to TIFF so the CAD software interprets the scale correctly.
 * 5. When generating printable marketing material from game assets, you convert the TGA to TIFF and set the DPI to 300 to match printer requirements.
 */
