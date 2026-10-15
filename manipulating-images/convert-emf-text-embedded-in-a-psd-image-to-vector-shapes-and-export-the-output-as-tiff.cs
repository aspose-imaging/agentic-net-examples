// HOW-TO: Convert PSD to TIFF While Preserving Raster Data in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.psd";
            string outputPath = "Output\\result.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image psdImage = Image.Load(inputPath))
            {
                // Ensure raster data is cached
                RasterImage rasterPsd = (RasterImage)psdImage;
                if (!rasterPsd.IsCached)
                {
                    rasterPsd.CacheData();
                }

                // Create TIFF canvas bound to output file
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);

                using (Image tiffImage = Image.Create(tiffOptions, rasterPsd.Width, rasterPsd.Height))
                {
                    RasterImage rasterTiff = (RasterImage)tiffImage;

                    // Copy pixel data from PSD to TIFF
                    Color[] pixels = rasterPsd.LoadPixels(rasterPsd.Bounds);
                    rasterTiff.SavePixels(rasterTiff.Bounds, pixels);

                    // Save the TIFF image (output file already bound)
                    tiffImage.Save();
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
 * 1. When you need to generate a high‑resolution TIFF from a Photoshop PSD for printing or archival purposes using C#.
 * 2. When an automated workflow must read a PSD file, ensure its pixel data is cached, and output a TIFF without losing image quality.
 * 3. When a server‑side application has to convert user‑uploaded PSD files to TIFF for compatibility with downstream imaging tools.
 * 4. When you want to programmatically create a TIFF file bound to a specific file path and copy pixel data from an existing PSD in .NET.
 * 5. When you need to handle missing PSD files gracefully and log errors while performing format conversion in a batch process.
 */
