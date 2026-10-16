// HOW-TO: Combine CDR and TIFF Pages into a PDF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string cdrPath = "Input\\sample.cdr";
            string tiffPath = "Input\\sample.tif";
            string outputPath = "Output\\combined.pdf";

            if (!File.Exists(cdrPath))
            {
                Console.Error.WriteLine($"File not found: {cdrPath}");
                return;
            }

            if (!File.Exists(tiffPath))
            {
                Console.Error.WriteLine($"File not found: {tiffPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image cdrImage = Image.Load(cdrPath))
            {
                IMultipageImage cdrMulti = cdrImage as IMultipageImage;
                if (cdrMulti == null)
                {
                    Console.Error.WriteLine("CDR image does not support multipage operations.");
                    return;
                }

                using (Image tiffImage = Image.Load(tiffPath))
                {
                    IMultipageImage tiffMulti = tiffImage as IMultipageImage;
                    if (tiffMulti == null)
                    {
                        Console.Error.WriteLine("TIFF image does not support multipage operations.");
                        return;
                    }

                    int canvasWidth = 0;
                    int canvasHeight = 0;

                    if (cdrMulti.PageCount > 0)
                    {
                        Image firstCdrPage = cdrMulti.Pages[0];
                        canvasWidth = firstCdrPage.Width;
                        canvasHeight = firstCdrPage.Height;
                    }
                    else if (tiffMulti.PageCount > 0)
                    {
                        Image firstTiffPage = tiffMulti.Pages[0];
                        canvasWidth = firstTiffPage.Width;
                        canvasHeight = firstTiffPage.Height;
                    }
                    else
                    {
                        Console.Error.WriteLine("No pages found in input images.");
                        return;
                    }

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    using (TiffImage canvas = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
                    {
                        foreach (Image page in cdrMulti.Pages)
                        {
                            canvas.AddPage((RasterImage)page);
                        }

                        foreach (Image page in tiffMulti.Pages)
                        {
                            canvas.AddPage((RasterImage)page);
                        }

                        using (PdfOptions pdfOptions = new PdfOptions())
                        {
                            canvas.Save(outputPath, pdfOptions);
                        }
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
 * 1. When you need to merge a CorelDRAW (CDR) illustration with scanned TIFF pages into one PDF for printing or distribution.
 * 2. When generating multi‑page PDF reports that combine vector artwork and raster scans without manually converting each page.
 * 3. When automating archival of mixed‑format assets by consolidating CDR designs and TIFF documents into a single searchable PDF file.
 * 4. When creating e‑books or product catalogs that include both original CDR graphics and multi‑page TIFF photographs in one PDF document.
 * 5. When building a batch workflow that converts legacy CDR files and multi‑page TIFFs into a combined PDF for compliance or documentation purposes.
 */
