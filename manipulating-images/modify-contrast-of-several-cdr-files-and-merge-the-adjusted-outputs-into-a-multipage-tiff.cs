// HOW-TO: Adjust Contrast Of Multiple Cdr Files And Merge Into Multipage Tiff In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new string[]
            {
                "input1.cdr",
                "input2.cdr",
                "input3.cdr"
            };
            string outputPath = "output\\merged.tif";

            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdrFirst = (CdrImage)Image.Load(inputPaths[0]))
            {
                int width = cdrFirst.Width;
                int height = cdrFirst.Height;

                using (MemoryStream msFirst = new MemoryStream())
                {
                    cdrFirst.Save(msFirst, new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = width,
                            PageHeight = height
                        }
                    });
                    msFirst.Position = 0;

                    using (RasterImage rasterFirst = (RasterImage)Image.Load(msFirst))
                    {
                        rasterFirst.AdjustContrast(0.5f);

                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
                        {
                            Color[] pixelsFirst = rasterFirst.LoadPixels(rasterFirst.Bounds);
                            tiff.SavePixels(tiff.ActiveFrame.Bounds, pixelsFirst);

                            for (int i = 1; i < inputPaths.Length; i++)
                            {
                                string path = inputPaths[i];
                                using (CdrImage cdr = (CdrImage)Image.Load(path))
                                {
                                    int w = cdr.Width;
                                    int h = cdr.Height;

                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        cdr.Save(ms, new PngOptions
                                        {
                                            VectorRasterizationOptions = new CdrRasterizationOptions
                                            {
                                                PageWidth = w,
                                                PageHeight = h
                                            }
                                        });
                                        ms.Position = 0;

                                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                                        {
                                            raster.AdjustContrast(0.5f);

                                            tiff.AddFrame(new TiffFrame(tiffOptions, w, h));
                                            tiff.ActiveFrame = tiff.Frames[tiff.Frames.Count() - 1];

                                            Color[] pixels = raster.LoadPixels(raster.Bounds);
                                            tiff.SavePixels(tiff.ActiveFrame.Bounds, pixels);
                                        }
                                    }
                                }
                            }

                            tiff.Save(outputPath);
                        }
                    }
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
 * 1. When you need to batch‑process a set of CorelDRAW (CDR) drawings, increase their contrast, and produce a single multipage TIFF for printing or archiving.
 * 2. When an application must convert CDR pages to PNG raster images, apply a contrast adjustment, and combine the results into a multi‑page TIFF for PDF generation downstream.
 * 3. When a workflow requires normalizing the visual intensity of several vector designs before merging them into a high‑resolution TIFF document for e‑catalog distribution.
 * 4. When automating the preparation of CDR artwork for OCR, you can boost contrast on each page and bundle them into one TIFF to simplify the scanning pipeline.
 * 5. When a desktop tool needs to read multiple CDR files, tweak their contrast programmatically in C#, and output a single TIFF file that can be opened by standard image viewers.
 */
