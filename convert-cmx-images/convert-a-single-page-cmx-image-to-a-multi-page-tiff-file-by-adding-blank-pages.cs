// HOW-TO: Convert CMX to Multi‑Page TIFF with Blank Pages in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int width = cmx.Width;
                int height = cmx.Height;

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    Graphics graphics = new Graphics(tiff);
                    graphics.DrawImage(cmx, new Rectangle(0, 0, width, height));

                    for (int i = 0; i < 2; i++)
                    {
                        var blankFrame = new TiffFrame(tiffOptions, width, height);
                        tiff.AddFrame(blankFrame);
                    }

                    tiff.Save(outputPath);
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
 * 1. When you need to archive a single‑page CMX drawing as a multi‑page TIFF document for compatibility with document management systems.
 * 2. When you must add placeholder pages to a TIFF file so that later processing steps can insert additional scans or annotations.
 * 3. When converting legacy CorelDRAW CMX files to a format that supports multiple pages for printing or PDF generation workflows.
 * 4. When an application requires a TIFF image stack with a specific page count, and you start from a single‑page CMX source.
 * 5. When integrating Aspose.Imaging into a C# service that prepares multi‑page TIFFs for medical or engineering records that include blank separator pages.
 */
