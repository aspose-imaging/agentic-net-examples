// HOW-TO: Batch Dither TIFF Images to PNG Using Floyd Steinberg in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Process .tif files
            foreach (string filePath in Directory.GetFiles(inputFolder, "*.tif"))
            {
                ProcessFile(filePath, outputFolder);
            }

            // Process .tiff files
            foreach (string filePath in Directory.GetFiles(inputFolder, "*.tiff"))
            {
                ProcessFile(filePath, outputFolder);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ProcessFile(string inputPath, string outputFolder)
    {
        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Determine output path
        string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".png");

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load, dither, and save the image
        using (Image image = Image.Load(inputPath))
        {
            if (image is RasterImage rasterImage)
            {
                // Apply Floyd‑Steinberg dithering with 8‑bit palette (256 colors)
                rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                // Save as PNG
                var pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
            }
            else
            {
                Console.Error.WriteLine($"Unsupported image type: {inputPath}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a large collection of high‑resolution TIFF scans into web‑friendly PNG files while preserving visual detail through Floyd‑Steinberg dithering.
 * 2. When an archival workflow requires batch processing of TIFF documents to reduce file size and maintain color fidelity for online publishing.
 * 3. When a desktop application must automatically transform incoming TIFF assets into 8‑bit PNGs for use in a graphics pipeline that only supports PNG input.
 * 4. When a server‑side service needs to generate PNG thumbnails from TIFF images with consistent dithering to ensure uniform appearance across browsers.
 * 5. When a migration script has to replace legacy TIFF images with PNG equivalents in a content management system while applying a standard 256‑color palette.
 */
