// HOW-TO: Create Multi‑Page TIFF From Multiple GIFs In C# (Aspose.Imaging for .NET)
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
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output/combined.tiff";

            string gifPath1 = "Input/gif1.gif";
            string gifPath2 = "Input/gif2.gif";
            string gifPath3 = "Input/gif3.gif";

            if (!File.Exists(gifPath1)) { Console.Error.WriteLine($"File not found: {gifPath1}"); return; }
            if (!File.Exists(gifPath2)) { Console.Error.WriteLine($"File not found: {gifPath2}"); return; }
            if (!File.Exists(gifPath3)) { Console.Error.WriteLine($"File not found: {gifPath3}"); return; }

            var frameDataList = new List<(int width, int height, Color[] pixels)>();
            var gifPaths = new[] { gifPath1, gifPath2, gifPath3 };

            foreach (var path in gifPaths)
            {
                using (GifImage gif = (GifImage)Image.Load(path))
                {
                    int pageCount = gif.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                        RasterImage raster = (RasterImage)gif;
                        if (!raster.IsCached) raster.CacheData();
                        int w = raster.Width;
                        int h = raster.Height;
                        Color[] pixels = raster.LoadPixels(raster.Bounds);
                        frameDataList.Add((w, h, pixels));
                    }
                }
            }

            if (frameDataList.Count == 0)
            {
                Console.Error.WriteLine("No frames extracted.");
                return;
            }

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            var first = frameDataList[0];
            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, first.width, first.height))
            {
                tiff.Frames[0].SavePixels(tiff.Frames[0].Bounds, first.pixels);

                for (int idx = 1; idx < frameDataList.Count; idx++)
                {
                    var f = frameDataList[idx];
                    tiff.AddFrame(new TiffFrame(tiffOptions, f.width, f.height));
                    int frameIndex = tiff.Frames.Count() - 1;
                    tiff.Frames[frameIndex].SavePixels(tiff.Frames[frameIndex].Bounds, f.pixels);
                }

                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrWhiteSpace(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                tiff.Save(outputPath, tiffOptions);
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
 * 1. When you need to combine animated GIF frames into a single printable document, you can generate a multi‑page TIFF for easy printing or archiving.
 * 2. When a web service must deliver a batch of GIF images as one file for downstream processing, creating a multi‑page TIFF simplifies transmission.
 * 3. When converting legacy animation assets into a format supported by office applications, assembling them into a TIFF allows insertion into Word or PowerPoint.
 * 4. When performing image analysis on each frame of several GIFs, storing all frames in a single TIFF enables sequential processing with standard raster tools.
 * 5. When building a digital archive that requires lossless storage of multiple GIF animations, consolidating them into a multi‑page TIFF preserves quality and metadata.
 */
