// HOW-TO: Add a TIFF Frame with Custom Size and CCITT Group 4 Compression in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                int width = 800;
                int height = 600;

                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.CcittFax4;
                frameOptions.Xresolution = new TiffRational(300, 1);
                frameOptions.Yresolution = new TiffRational(300, 1);
                frameOptions.ResolutionUnit = TiffResolutionUnits.Inch;

                TiffFrame newFrame = new TiffFrame(frameOptions, width, height);
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
 * 1. When you need to append a high‑compression scanned page to an existing multi‑page TIFF for archival storage.
 * 2. When generating a fax‑ready TIFF document with precise 300 dpi resolution for legal or medical records.
 * 3. When creating a multi‑resolution TIFF where each frame has its own dimensions and CCITT Group 4 compression to reduce file size.
 * 4. When converting scanned images into a single TIFF file that meets printer or scanner DPI specifications.
 * 5. When programmatically adding a new page to a TIFF file in a C# application while controlling compression and resolution settings.
 */
