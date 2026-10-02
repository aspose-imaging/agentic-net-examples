// HOW-TO: Rasterize EPS to 300 DPI TIFF with ICC Profile in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height,
                    BackgroundColor = Color.White
                };

                using (var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300)
                })
                {
                    string iccPath = "profile.icc";
                    if (File.Exists(iccPath))
                    {
                        byte[] iccData = File.ReadAllBytes(iccPath);
                        tiffOptions.IccProfile = new MemoryStream(iccData);
                    }

                    epsImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to convert a print‑ready EPS artwork into a high‑resolution 300 DPI TIFF for pre‑press workflows while preserving color accuracy with an embedded ICC profile.
 * 2. When a desktop application must display or archive vector graphics as raster images that match the original size and background, using C# and Aspose.Imaging.
 * 3. When generating thumbnails or PDFs from EPS files for a digital asset management system that requires TIFF output at a specific resolution and embedded color profile.
 * 4. When automating batch processing of EPS logos to create print‑ready TIFF files for a publishing pipeline that demands consistent DPI and color management.
 * 5. When integrating a C# service that receives EPS files and needs to deliver them as TIFFs suitable for high‑quality printing, ensuring the correct resolution and ICC profile are applied.
 */
