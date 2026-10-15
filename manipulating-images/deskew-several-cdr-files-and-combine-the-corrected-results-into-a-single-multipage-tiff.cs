// HOW-TO: Deskew Multiple Cdr Files And Merge Into Multi‑Page Tiff In C# (Aspose.Imaging for .NET)
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
            string cdrPath1 = "input1.cdr";
            string cdrPath2 = "input2.cdr";
            string cdrPath3 = "input3.cdr";
            string outputPath = "output\\combined.tif";

            if (!File.Exists(cdrPath1)) { Console.Error.WriteLine($"File not found: {cdrPath1}"); return; }
            if (!File.Exists(cdrPath2)) { Console.Error.WriteLine($"File not found: {cdrPath2}"); return; }
            if (!File.Exists(cdrPath3)) { Console.Error.WriteLine($"File not found: {cdrPath3}"); return; }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] inputPaths = new string[] { cdrPath1, cdrPath2, cdrPath3 };
            TiffImage tiffImage = null;
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            foreach (string inputPath in inputPaths)
            {
                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
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
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            raster.NormalizeAngle(false, Aspose.Imaging.Color.White);
                            if (tiffImage == null)
                            {
                                tiffImage = (TiffImage)Image.Create(tiffOptions, raster.Width, raster.Height);
                                tiffImage.SavePixels(tiffImage.ActiveFrame.Bounds, raster.LoadPixels(raster.Bounds));
                            }
                            else
                            {
                                tiffImage.AddPage(raster);
                            }
                        }
                    }
                }
            }

            if (tiffImage != null)
            {
                using (tiffImage)
                {
                    tiffImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to automatically correct the orientation of scanned CorelDRAW (CDR) drawings before archiving them as a single searchable TIFF document.
 * 2. When a batch of CDR artwork must be rasterized, deskewed, and combined into a multi‑page TIFF for printing or PDF conversion pipelines.
 * 3. When a document management system requires all vector designs to be stored as a consolidated TIFF file with each original CDR page as a separate frame.
 * 4. When you want to preprocess CDR files to remove skew and then create a multi‑page TIFF for OCR processing or archival compliance.
 * 5. When integrating Aspose.Imaging into a C# application to transform multiple CDR files into a single TIFF while ensuring proper alignment for downstream image analysis.
 */
