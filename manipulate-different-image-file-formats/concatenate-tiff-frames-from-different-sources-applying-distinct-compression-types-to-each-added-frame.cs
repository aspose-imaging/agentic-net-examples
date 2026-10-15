// HOW-TO: Combine Multiple TIFF Files with Different Compression per Frame in C# (Aspose.Imaging for .NET)
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
        string inputPath1 = "input1.tif";
        string inputPath2 = "input2.tif";
        string outputPath = "output/combined.tif";

        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.RasterImage img1 = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath1))
            {
                int width = img1.Width;
                int height = img1.Height;

                FileCreateSource outSource = new FileCreateSource(outputPath, false);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = outSource,
                    Compression = TiffCompressions.Lzw
                };

                using (TiffImage tiffImage = (TiffImage)Aspose.Imaging.Image.Create(tiffOptions, width, height))
                {
                    tiffImage.SaveArgb32Pixels(tiffImage.Bounds, img1.LoadArgb32Pixels(img1.Bounds));

                    using (Aspose.Imaging.RasterImage img2 = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath2))
                    {
                        TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            Compression = TiffCompressions.Jpeg
                        };
                        TiffFrame frame2 = new TiffFrame(frameOptions, img2.Width, img2.Height);
                        frame2.SaveArgb32Pixels(frame2.Bounds, img2.LoadArgb32Pixels(img2.Bounds));
                        tiffImage.AddFrame(frame2);
                    }

                    tiffImage.Save();
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
 * 1. When you need to merge scanned documents stored as separate TIFF files into a single multi‑page TIFF while using LZW compression for the first page and JPEG compression for the second page.
 * 2. When creating a PDF‑like bundle of medical images where each image must retain its own optimal compression to balance quality and file size.
 * 3. When generating a multi‑page TIFF archive for archival purposes and want to apply lossless compression to the cover page and lossy compression to the remaining pages.
 * 4. When building a document management system that combines TIFF images from different sources and requires different compression algorithms for each frame to meet storage policies.
 * 5. When automating the preparation of TIFF image sequences for printing, assigning LZW compression to high‑resolution pages and JPEG compression to lower‑resolution pages to reduce overall file size.
 */
