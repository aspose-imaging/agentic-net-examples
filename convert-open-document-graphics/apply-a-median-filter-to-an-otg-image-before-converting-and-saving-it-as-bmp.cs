// HOW-TO: Apply Median Filter to OTG Image and Save as BMP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.otg";
            string outputPath = "Output\\image.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, bmpOptions);
                    ms.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                    {
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                        raster.Save(outputPath, new BmpOptions());
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
 * 1. When you need to reduce noise in an OTG vector graphic before converting it to a BMP for legacy Windows applications.
 * 2. When you must batch‑process scanned OTG files, apply a median filter, and store the results as BMPs for further analysis.
 * 3. When a medical imaging workflow requires cleaning up OTG images with a median filter before saving them in BMP format for compatibility with older diagnostic tools.
 * 4. When you are building a document conversion service that receives OTG files, applies noise reduction, and outputs BMPs for downstream OCR engines.
 * 5. When you need to programmatically prepare OTG artwork for printing by filtering out speckles and exporting the cleaned image as a BMP in a .NET application.
 */
