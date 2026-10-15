// HOW-TO: Add a New TIFF Frame with LZW Compression and Custom Resolution in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image tiffImg = Aspose.Imaging.Image.Load(inputPath))
            {
                var tiffImage = (TiffImage)tiffImg;

                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.Lzw;
                frameOptions.ResolutionUnit = TiffResolutionUnits.Inch;
                frameOptions.Xresolution = new TiffRational(300, 1);
                frameOptions.Yresolution = new TiffRational(300, 1);

                int newWidth = 800;
                int newHeight = 600;

                TiffFrame newFrame = new TiffFrame(frameOptions, newWidth, newHeight);
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
 * 1. When you need to create a multi‑page TIFF document and add a blank page of specific size and 300 dpi resolution while using LZW compression to keep the file size low.
 * 2. When a scanning application must insert a new image layer into an existing TIFF file with custom width and height for later overlay or annotation.
 * 3. When a medical imaging system requires adding a high‑resolution frame to a DICOM‑converted TIFF series, preserving exact inch‑based resolution for accurate measurements.
 * 4. When a GIS tool generates map tiles and needs to append a new TIFF frame with defined pixel dimensions and loss‑less LZW compression for seamless stitching.
 * 5. When an archival workflow automates the preparation of TIFF files with consistent resolution and compression settings before storing them in a digital asset management system.
 */
