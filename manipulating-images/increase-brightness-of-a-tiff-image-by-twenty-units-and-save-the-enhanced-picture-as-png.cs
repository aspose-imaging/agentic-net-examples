// HOW-TO: Increase TIFF Brightness by 20 and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.tif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image img = Image.Load(inputPath))
            {
                if (img is RasterImage raster)
                {
                    raster.AdjustBrightness(20);
                    raster.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
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
 * 1. When you need to enhance a scanned document's visibility before converting it to a web‑friendly PNG format.
 * 2. When processing medical imaging TIFF files that require a slight brightness boost for better diagnostic review and then storing them as PNG for integration with other systems.
 * 3. When automating a batch job that adjusts the brightness of archival TIFF photographs by a fixed amount and outputs them as PNG thumbnails.
 * 4. When preparing TIFF maps for a GIS application that expects brighter imagery and PNG input, using C# to adjust and convert them.
 * 5. When developing a .NET service that receives TIFF uploads, applies a uniform brightness correction, and returns the result as a PNG for client display.
 */
