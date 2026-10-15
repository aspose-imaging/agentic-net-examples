// HOW-TO: Apply Emboss Filter to JPEG and Save as TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                double[,] embossKernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1, 1, 1 },
                    { 0, 1, 2 }
                };

                var filterOptions = new ConvolutionFilterOptions(embossKernel);
                raster.Filter(raster.Bounds, filterOptions);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to add a stylized emboss effect to user‑uploaded JPEG photos before archiving them as lossless TIFF files.
 * 2. When a document‑management system must convert scanned JPEG images into TIFF while enhancing edges for better OCR readability.
 * 3. When a web service generates printable TIFF assets from JPEG product images and wants a quick 3×3 convolution to highlight texture.
 * 4. When a batch‑processing tool applies a custom kernel to JPEG graphics to create a raised‑look preview and stores the result in TIFF for downstream workflows.
 * 5. When a desktop application needs to demonstrate Aspose.Imaging’s convolution filter by embossing a JPEG and exporting the result to a TIFF for archival quality.
 */
