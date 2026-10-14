// HOW-TO: Convert Multi‑Page CMX to Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\result.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                var pageOptions = new VectorRasterizationOptions[cmxImage.PageCount];

                for (int i = 0; i < cmxImage.PageCount; i++)
                {
                    pageOptions[i] = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cmxImage.Width,
                        PageHeight = cmxImage.Height
                    };
                }

                tiffOptions.MultiPageOptions = new MultiPageOptions
                {
                    PageRasterizationOptions = pageOptions
                };

                cmxImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive a multi‑page CorelDRAW CMX document as a searchable multi‑page TIFF for long‑term storage.
 * 2. When a printing workflow requires converting CMX vector pages to raster TIFF pages while keeping the original page sequence.
 * 3. When an application must batch‑process CMX files and output them as multi‑page TIFFs for compatibility with legacy imaging systems.
 * 4. When you want to generate white‑background TIFF previews of each CMX page for web preview or document management portals.
 * 5. When integrating Aspose.Imaging in a C# service that transforms vector CMX drawings into TIFF files for downstream OCR or PDF conversion.
 */
