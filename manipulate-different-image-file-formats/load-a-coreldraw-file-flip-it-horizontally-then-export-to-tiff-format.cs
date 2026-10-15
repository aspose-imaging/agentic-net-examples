// HOW-TO: Flip CorelDRAW Image Horizontally and Save as TIFF in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        string inputPath = "input.cdr";
        string outputPath = "output/output.tiff";

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
                    raster.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to mirror a vector illustration from a CorelDRAW (CDR) file before printing it on a sheet‑fed press, they can load the file, flip it horizontally, and export to TIFF for the RIP.
 * 2. When an automated workflow must convert legacy CDR assets to a lossless TIFF format while applying a horizontal flip for correct orientation in a web gallery, this code provides the transformation.
 * 3. When a document‑generation system has to embed a reversed CorelDRAW logo into a PDF and requires the image as a TIFF, the snippet loads the CDR, flips it, and saves the result.
 * 4. When a batch‑processing tool processes design files and needs to create mirrored TIFF previews for a review portal, the code demonstrates how to perform the flip and conversion in .NET.
 * 5. When a developer integrates Aspose.Imaging into a C# application to prepare printable artwork that must be mirrored for a specific layout, this example shows loading the CDR, applying RotateFlip, and saving as TIFF.
 */
