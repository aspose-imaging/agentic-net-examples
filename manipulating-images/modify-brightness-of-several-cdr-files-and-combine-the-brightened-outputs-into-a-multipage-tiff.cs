// HOW-TO: Adjust Brightness of Multiple CDR Files and Create Multipage TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(cdrPath1)) { Console.Error.WriteLine($"File not found: {cdrPath1}"); return; }
            if (!File.Exists(cdrPath2)) { Console.Error.WriteLine($"File not found: {cdrPath2}"); return; }
            if (!File.Exists(cdrPath3)) { Console.Error.WriteLine($"File not found: {cdrPath3}"); return; }

            var cdrPaths = new List<string> { cdrPath1, cdrPath2, cdrPath3 };
            TiffImage tiffImage = null;
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            foreach (var cdrPath in cdrPaths)
            {
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    using (MemoryStream ms = new MemoryStream())
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

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            raster.AdjustBrightness(50);

                            if (tiffImage == null)
                            {
                                tiffImage = (TiffImage)Image.Create(tiffOptions, raster.Width, raster.Height);
                            }
                            else
                            {
                                tiffImage.AddFrame(new TiffFrame(tiffOptions, raster.Width, raster.Height));
                            }

                            var frame = tiffImage.Frames[tiffImage.PageCount - 1];
                            Color[] pixels = raster.LoadPixels(raster.Bounds);
                            frame.SavePixels(frame.Bounds, pixels);
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
 * 1. When a designer needs to batch‑process CorelDRAW (CDR) artwork, increase its brightness, and deliver the results as a single multipage TIFF for printing or archiving.
 * 2. When an automated workflow must convert several CDR pages to raster images, apply a uniform brightness adjustment, and combine them into one TIFF document for downstream OCR or document management systems.
 * 3. When a web service receives multiple CDR files, needs to enhance visibility by brightening each page, and returns a combined TIFF to be displayed in a viewer that only supports TIFF.
 * 4. When a publishing pipeline requires converting vector CDR files to a high‑resolution TIFF while ensuring consistent brightness across all pages before sending to a print shop.
 * 5. When a backup script has to normalize the appearance of archived CDR drawings by brightening them and storing them compactly as a single multipage TIFF file.
 */
