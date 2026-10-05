// HOW-TO: Add a PNG Frame to an Existing TIFF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputTiffPath = "input.tif";
            string inputAdditionalPath = "additional.png";
            string outputPath = "output\\output.tif";

            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }

            if (!File.Exists(inputAdditionalPath))
            {
                Console.Error.WriteLine($"File not found: {inputAdditionalPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] tiffBytes = File.ReadAllBytes(inputTiffPath);
            using (var tiffStream = new MemoryStream(tiffBytes))
            using (TiffImage tiffImage = (TiffImage)Image.Load(tiffStream))
            using (Image addImage = Image.Load(inputAdditionalPath))
            {
                RasterImage raster = (RasterImage)addImage;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                TiffFrame newFrame = new TiffFrame(tiffOptions, raster.Width, raster.Height);
                newFrame.SavePixels(newFrame.Bounds, raster.LoadPixels(raster.Bounds));

                tiffImage.AddFrame(newFrame);
                tiffImage.Save(outputPath);
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
 * 1. When you need to combine a PNG image as an additional page in a multi‑page TIFF document for archival or printing purposes.
 * 2. When you want to load a TIFF from a byte array or network stream, append new frames, and save the updated file without writing the original to disk first.
 * 3. When you are building a C# service that merges scanned PDFs (converted to TIFF) with supplemental graphics, such as logos or signatures, into a single TIFF file.
 * 4. When you must programmatically create a multi‑frame TIFF from separate image sources (e.g., PNG, JPEG) while preserving each frame’s original dimensions and pixel data.
 * 5. When you need to automate the generation of a TIFF slideshow where each slide is sourced from different image files and the result must be saved to a specific output folder.
 */
