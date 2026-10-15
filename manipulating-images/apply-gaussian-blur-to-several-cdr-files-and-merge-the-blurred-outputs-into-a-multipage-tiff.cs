// HOW-TO: Apply Gaussian Blur to Multiple CDR Files and Merge into Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] cdrPaths = new string[]
            {
                "input1.cdr",
                "input2.cdr",
                "input3.cdr"
            };

            string outputPath = "output/merged.tif";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            foreach (var path in cdrPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
            TiffImage tiffImage = null;

            for (int i = 0; i < cdrPaths.Length; i++)
            {
                string cdrPath = cdrPaths[i];
                using (var cdr = (CdrImage)Image.Load(cdrPath))
                {
                    using (var ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new CdrRasterizationOptions
                            {
                                PageWidth = cdr.Width,
                                PageHeight = cdr.Height
                            }
                        };
                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;
                        using (var raster = (RasterImage)Image.Load(ms))
                        {
                            var blurOptions = new GaussianBlurFilterOptions(5, 1.0f);
                            raster.Filter(raster.Bounds, blurOptions);

                            if (i == 0)
                            {
                                tiffImage = (TiffImage)Image.Create(tiffOptions, raster.Width, raster.Height);
                                tiffImage.SavePixels(tiffImage.Bounds, raster.LoadPixels(raster.Bounds));
                            }
                            else
                            {
                                tiffImage.AddPage(new TiffFrame(tiffOptions, raster.Width, raster.Height));
                                var frame = tiffImage.Frames[i];
                                frame.SavePixels(frame.Bounds, raster.LoadPixels(raster.Bounds));
                            }
                        }
                    }
                }
            }

            if (tiffImage != null)
            {
                tiffImage.Save(outputPath);
                tiffImage.Dispose();
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
 * 1. When you need to create a blurred preview of several CorelDRAW (CDR) drawings and combine them into a single searchable multi‑page TIFF for archival or printing.
 * 2. When an application must programmatically convert CDR pages to raster images, apply a Gaussian blur filter for aesthetic or privacy reasons, and output the results as a compressed LZW TIFF.
 * 3. When a batch processing tool has to load multiple vector CDR files, rasterize them to PNG, apply a 5‑pixel radius blur, and merge the blurred pages into one TIFF document for easy distribution.
 * 4. When you want to automate the generation of blurred thumbnails from CDR artwork and store them in a multi‑page TIFF to be used in document management systems.
 * 5. When a .NET service needs to read CDR files, apply image filtering, and produce a single TIFF file that can be opened by standard image viewers without requiring CorelDRAW.
 */
