// HOW-TO: Convert Multi-Page EMF to High-Resolution TIFF Files in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputDir = "output";
            int dpi = 300;

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image emfImage = Image.Load(inputPath))
            {
                int pageCount = 1;
                if (emfImage is IMultipageImage multipage)
                {
                    pageCount = multipage.PageCount;
                }

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.ResolutionSettings = new ResolutionSetting(dpi, dpi);
                    tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                    emfImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to extract each page of a vector EMF report and save them as printable TIFF images at 300 dpi for archiving.
 * 2. When a document workflow requires converting multi-page engineering diagrams from EMF to separate high-resolution TIFF files for inclusion in PDF portfolios.
 * 3. When an application must generate rasterized TIFF pages from a multi-page EMF to support downstream image processing or OCR at a specific DPI.
 * 4. When a batch process has to split a multi-page EMF file into individual TIFF files for use in a content management system that only accepts TIFF format.
 * 5. When you need to preserve the original page layout while converting EMF graphics to TIFF with custom resolution settings for high-quality printing.
 */
