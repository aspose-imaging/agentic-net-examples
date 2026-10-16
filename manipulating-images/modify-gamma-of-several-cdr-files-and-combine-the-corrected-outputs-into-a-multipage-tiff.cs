// HOW-TO: Adjust Gamma of Multiple CDR Files and Create a Multipage TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR file paths
            string cdrPath1 = "input1.cdr";
            string cdrPath2 = "input2.cdr";
            List<string> cdrPaths = new List<string> { cdrPath1, cdrPath2 };

            // Hardcoded output TIFF path
            string outputTiffPath = "output/multipage.tif";

            // Verify input files exist
            foreach (var path in cdrPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

            // List to hold raster images and their streams
            List<(RasterImage raster, MemoryStream stream)> rasterData = new List<(RasterImage, MemoryStream)>();

            // Process each CDR file: rasterize, adjust gamma, store raster
            foreach (var cdrPath in cdrPaths)
            {
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    MemoryStream ms = new MemoryStream();
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;
                    RasterImage raster = (RasterImage)Image.Load(ms);
                    raster.AdjustGamma(1.2f);
                    rasterData.Add((raster, ms));
                }
            }

            // Create multipage TIFF
            int width = rasterData[0].raster.Width;
            int height = rasterData[0].raster.Height;
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // First frame
                tiff.ActiveFrame.SavePixels(tiff.ActiveFrame.Bounds, rasterData[0].raster.LoadPixels(rasterData[0].raster.Bounds));

                // Additional frames
                for (int i = 1; i < rasterData.Count; i++)
                {
                    tiff.AddFrame(new TiffFrame(tiffOptions, width, height));
                    tiff.ActiveFrame.SavePixels(tiff.ActiveFrame.Bounds, rasterData[i].raster.LoadPixels(rasterData[i].raster.Bounds));
                }

                // Save TIFF
                tiff.Save(outputTiffPath);
            }

            // Dispose raster images and streams
            foreach (var (raster, stream) in rasterData)
            {
                raster.Dispose();
                stream.Dispose();
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
 * 1. When a designer needs to correct the brightness of several CorelDRAW (CDR) illustrations before archiving them as a single multipage TIFF for printing.
 * 2. When an automated batch process must convert a collection of CDR assets to raster images, apply gamma correction, and store them in a searchable TIFF document.
 * 3. When a web service generates preview PDFs and wants to embed gamma‑adjusted CDR pages into a multipage TIFF for downstream OCR processing.
 * 4. When a legacy workflow requires merging multiple CDR drawings into one TIFF file with consistent gamma to ensure uniform visual appearance across all pages.
 * 5. When a digital asset management system needs to ingest CDR files, normalize their gamma, and store them as a single multipage TIFF for easy preview and thumbnail generation.
 */
