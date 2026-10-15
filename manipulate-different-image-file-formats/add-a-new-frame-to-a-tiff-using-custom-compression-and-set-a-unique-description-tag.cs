// HOW-TO: Add a New LZW Compressed Frame to an Existing TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.Lzw;

                int width = tiff.Width;
                int height = tiff.Height;

                TiffFrame newFrame = new TiffFrame(frameOptions, width, height);
                tiff.AddFrame(newFrame);
                tiff.Save(outputPath);
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
 * 1. When you need to append an extra page to a multi‑page TIFF while keeping file size low by using LZW compression.
 * 2. When a document‑scanning application must combine newly scanned images with an existing TIFF archive without re‑encoding the original pages.
 * 3. When a medical imaging system wants to add a diagnostic overlay as a separate frame to a TIFF file and preserve lossless compression.
 * 4. When a GIS workflow requires inserting a new raster layer into a multi‑band TIFF and control the compression algorithm programmatically.
 * 5. When an automated report generator creates a summary page and needs to attach it as an additional frame to a TIFF portfolio using Aspose.Imaging for .NET.
 */
