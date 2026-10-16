// HOW-TO: Convert Multi-Page PDF Maps to High-Resolution TIFF Files in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPdfPath = "Input\\maps.pdf";
            string outputDir = "Output";

            if (!File.Exists(inputPdfPath))
            {
                Console.Error.WriteLine($"File not found: {inputPdfPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image pdfImage = Image.Load(inputPdfPath))
            {
                if (pdfImage is IMultipageImage multipage)
                {
                    int pageCount = multipage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.tif");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = 3000,
                            PageHeight = 4000,
                            BackgroundColor = Color.White
                        };
                        tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                        pdfImage.Save(outputPath, tiffOptions);
                    }
                }
                else
                {
                    string outputPath = Path.Combine(outputDir, "page_1.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = 3000,
                        PageHeight = 4000,
                        BackgroundColor = Color.White
                    };

                    pdfImage.Save(outputPath, tiffOptions);
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
 * 1. When a GIS developer must split a multi‑page PDF containing vector maps into individual high‑resolution TIFF images for layer‑by‑layer spatial analysis.
 * 2. When an application needs to rasterize vector PDF maps at a specific pixel size (e.g., 3000 × 4000) to create TIFF files suitable for image‑processing algorithms.
 * 3. When an organization wants to archive each page of a PDF map collection as separate TIFF files with a white background for consistent viewing across platforms.
 * 4. When a data‑conversion pipeline requires converting PDF pages to single‑page TIFFs before feeding them into machine‑learning models that accept only TIFF input.
 * 5. When a printing workflow demands high‑resolution TIFF outputs from PDF maps, with each page saved as an individual file for precise print layout control.
 */
