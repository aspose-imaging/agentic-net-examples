// HOW-TO: Convert DjVu Pages 1‑3 to PNG and Combine into Multipage TIFF C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputDjvuPath = "input.djvu";
                if (!File.Exists(inputDjvuPath))
                {
                    Console.Error.WriteLine($"File not found: {inputDjvuPath}");
                    return;
                }

                string[] pngPaths = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    pngPaths[i] = $"page{i + 1}.png";
                    string pngDir = Path.GetDirectoryName(pngPaths[i]) ?? ".";
                    Directory.CreateDirectory(pngDir);

                    using (DjvuImage djvu = (DjvuImage)Image.Load(inputDjvuPath))
                    {
                        PngOptions pngOptions = new PngOptions();
                        pngOptions.MultiPageOptions = new DjvuMultiPageOptions(i);
                        djvu.Save(pngPaths[i], pngOptions);
                    }
                }

                using (RasterImage firstPng = (RasterImage)Image.Load(pngPaths[0]))
                {
                    int width = firstPng.Width;
                    int height = firstPng.Height;

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
                    {
                        int[] pixels = firstPng.LoadArgb32Pixels(firstPng.Bounds);
                        ((RasterImage)tiffImage).SaveArgb32Pixels(tiffImage.Bounds, pixels);

                        for (int i = 1; i < pngPaths.Length; i++)
                        {
                            using (RasterImage png = (RasterImage)Image.Load(pngPaths[i]))
                            {
                                int[] framePixels = png.LoadArgb32Pixels(png.Bounds);
                                tiffImage.AddFrame(new TiffFrame(tiffOptions, width, height));
                                tiffImage.ActiveFrame = tiffImage.Frames[tiffImage.Frames.Count() - 1];
                                ((RasterImage)tiffImage).SaveArgb32Pixels(tiffImage.Bounds, framePixels);
                            }
                        }

                        string outputTiffPath = "output.tif";
                        string outDir = Path.GetDirectoryName(outputTiffPath) ?? ".";
                        Directory.CreateDirectory(outDir);
                        tiffImage.Save(outputTiffPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract the first three pages of a DjVu document as high‑quality PNG images for web preview before creating a single multipage TIFF for archival storage.
 * 2. When a scanning workflow requires converting selected DjVu pages to PNG to apply image processing, then merging them into a TIFF file for compatibility with legacy document management systems.
 * 3. When generating printable PDFs from DjVu sources, you can first create PNGs of specific pages and then combine them into a TIFF that can be easily embedded into PDF generation tools.
 * 4. When building a batch job that processes large DjVu files, extracting only the initial pages as PNGs reduces memory usage before consolidating them into a compact multipage TIFF for distribution.
 * 5. When creating a digital catalog, you may convert key DjVu pages to PNG for thumbnail display and then merge those thumbnails into a single TIFF to simplify storage and retrieval.
 */
