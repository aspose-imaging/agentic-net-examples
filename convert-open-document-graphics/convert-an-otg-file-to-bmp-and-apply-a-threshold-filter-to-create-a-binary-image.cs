// HOW-TO: Convert OTG to BMP with Fixed Threshold Binarization in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        string inputPath = "input.otg";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                // Apply fixed threshold binarization (example threshold: 128)
                raster.BinarizeFixed(128);

                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 1
                };

                raster.Save(outputPath, bmpOptions);
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
 * 1. When you need to transform legacy OTG graphics into 1‑bit BMP files for embedding in low‑color‑depth UI components.
 * 2. When you must preprocess scanned OTG drawings by applying a fixed threshold to produce a binary image for OCR or pattern recognition.
 * 3. When a printing workflow requires converting OTG artwork to monochrome BMP to meet printer firmware that only accepts 1‑bpp images.
 * 4. When you are building a batch conversion tool that reads OTG files, binarizes them at a specific intensity, and saves them as BMP for archival storage.
 * 5. When integrating Aspose.Imaging in a C# application to generate black‑and‑white BMP masks from OTG source files for use in computer‑vision segmentation.
 */
