// HOW-TO: Add Custom Sized LZW Compressed TIFF Frame with Resolution in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.tif";
            string outputPath = "output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Define custom dimensions for the new frame
                int newWidth = 800;
                int newHeight = 600;

                // Create TiffOptions for the new frame with LZW compression and resolution settings
                using (TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb))
                {
                    frameOptions.Xresolution = new TiffRational(300, 1);
                    frameOptions.Yresolution = new TiffRational(300, 1);
                    frameOptions.ResolutionUnit = TiffResolutionUnits.Inch;

                    TiffFrame newFrame = new TiffFrame(frameOptions, newWidth, newHeight);
                    tiffImage.AddFrame(newFrame);
                }

                // Save the updated TIFF with desired options
                using (TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb))
                {
                    saveOptions.Xresolution = new TiffRational(300, 1);
                    saveOptions.Yresolution = new TiffRational(300, 1);
                    saveOptions.ResolutionUnit = TiffResolutionUnits.Inch;

                    tiffImage.Save(outputPath, saveOptions);
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
 * 1. When you need to append a new page of specific width and height to an existing multi‑page TIFF for printing at 300 dpi using LZW compression.
 * 2. When generating a multi‑resolution TIFF document where each frame must have its own resolution metadata and lossless compression in a C# application.
 * 3. When converting scanned images into a single TIFF file and want to add a blank canvas of custom dimensions as a placeholder frame.
 * 4. When creating a TIFF archive for archival purposes and must ensure each added frame uses LZW compression and standardized inch resolution settings.
 * 5. When automating the preparation of TIFF files for GIS or medical imaging systems that require exact pixel dimensions and resolution tags per frame.
 */
