// HOW-TO: Extract WebP Animation Frames and Combine into Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/animation.webp";
            string outputPath = "Output/combined.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                int width = webp.Width;
                int height = webp.Height;
                int frameCount = webp.Pages.Length;

                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
                    {
                        // Process first frame
                        RasterImage firstRaster = (RasterImage)webp.Pages[0];
                        var firstPixels = firstRaster.LoadPixels(firstRaster.Bounds);
                        tiff.Frames[0].SavePixels(tiff.Frames[0].Bounds, firstPixels);

                        // Process remaining frames
                        for (int i = 1; i < frameCount; i++)
                        {
                            tiff.AddFrame(new TiffFrame(tiffOptions, width, height));
                            RasterImage frameRaster = (RasterImage)webp.Pages[i];
                            var framePixels = frameRaster.LoadPixels(frameRaster.Bounds);
                            tiff.Frames[i].SavePixels(tiff.Frames[i].Bounds, framePixels);
                        }

                        tiff.Save(outputPath);
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
 * 1. When you need to convert an animated WebP file into a multi‑page TIFF for archival or printing workflows.
 * 2. When a web application must display each frame of a WebP animation as separate images in a document viewer that only supports TIFF.
 * 3. When you want to extract individual frames from a WebP animation to perform per‑frame analysis or processing in C#.
 * 4. When integrating legacy systems that require TIFF input but the source assets are delivered as animated WebP files.
 * 5. When creating a composite TIFF file from a WebP animation to embed into PDFs or reports that accept only TIFF images.
 */
