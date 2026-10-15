// HOW-TO: Apply Custom Convolution Kernel to Each Page of a Multipage SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (!(image is IMultipageImage multipage))
                {
                    Console.Error.WriteLine("The loaded image does not support multiple pages.");
                    return;
                }

                List<RasterImage> processedPages = new List<RasterImage>();

                for (int i = 0; i < multipage.PageCount; i++)
                {
                    Image page = multipage.Pages[i];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions();
                        page.Save(ms, pngOptions);
                        ms.Position = 0;
                        RasterImage raster = (RasterImage)Image.Load(ms);
                        double[,] kernel = new double[,]
                        {
                            { 0, -1, 0 },
                            { -1, 5, -1 },
                            { 0, -1, 0 }
                        };
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);
                        processedPages.Add(raster);
                    }
                    page.Dispose();
                }

                if (processedPages.Count == 0)
                {
                    Console.Error.WriteLine("No pages processed.");
                    return;
                }

                using (TiffImage tiff = new TiffImage(new TiffFrame(processedPages[0])))
                {
                    for (int i = 1; i < processedPages.Count; i++)
                    {
                        tiff.AddPage(processedPages[i]);
                    }

                    var tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
                    tiff.Save(outputPath, tiffOptions);
                }

                foreach (var raster in processedPages)
                {
                    raster.Dispose();
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
 * 1. When you need to sharpen every layer of a multi‑page SVG before converting it to a raster format such as TIFF.
 * 2. When you want to programmatically enhance vector graphics for printing by applying a custom filter to each page in C#.
 * 3. When you must batch‑process SVG diagrams and apply the same image‑processing kernel to maintain visual consistency across all pages.
 * 4. When you are building a server‑side service that receives multi‑page SVG files and needs to apply edge‑enhancement before storing them as raster images.
 * 5. When you require automated preprocessing of SVG assets for a PDF generation pipeline, applying a convolution filter to each page to improve clarity.
 */
