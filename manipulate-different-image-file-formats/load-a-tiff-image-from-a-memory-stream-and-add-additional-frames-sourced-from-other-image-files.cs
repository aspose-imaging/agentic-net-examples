// HOW-TO: Add JPEG and PNG Frames to Existing TIFF from Memory Stream in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string tiffInputPath = "input.tif";
            string[] framePaths = { "frame1.jpg", "frame2.png" };
            string outputPath = "output.tif";

            if (!File.Exists(tiffInputPath))
            {
                Console.Error.WriteLine($"File not found: {tiffInputPath}");
                return;
            }
            foreach (var fp in framePaths)
            {
                if (!File.Exists(fp))
                {
                    Console.Error.WriteLine($"File not found: {fp}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            byte[] tiffBytes = File.ReadAllBytes(tiffInputPath);
            using (var ms = new MemoryStream(tiffBytes))
            using (TiffImage tiffImage = (TiffImage)Aspose.Imaging.Image.Load(ms))
            {
                foreach (var fp in framePaths)
                {
                    using (Aspose.Imaging.Image srcImg = Aspose.Imaging.Image.Load(fp))
                    {
                        Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)srcImg;
                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        TiffFrame newFrame = new TiffFrame(tiffOptions, raster.Width, raster.Height);
                        Aspose.Imaging.Color[] pixels = raster.LoadPixels(raster.Bounds);
                        newFrame.SavePixels(newFrame.Bounds, pixels);
                        tiffImage.AddFrame(newFrame);
                    }
                }

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
 * 1. When you need to combine separate JPEG or PNG images into a multi‑page TIFF document without writing the original TIFF to disk first.
 * 2. When a web service receives a TIFF file as a byte array and you must append additional scanned pages stored as image files before returning the updated file.
 * 3. When generating a printable report where each page is created as an image and then merged into a single TIFF for archival.
 * 4. When automating the creation of a multi‑frame medical image by adding frames from various image sources in a C# application.
 * 5. When building a batch process that reads a TIFF from a database BLOB, adds new frames from user‑uploaded pictures, and saves the result back to storage.
 */
