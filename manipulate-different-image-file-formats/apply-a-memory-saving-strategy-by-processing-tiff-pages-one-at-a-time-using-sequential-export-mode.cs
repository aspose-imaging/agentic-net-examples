// HOW-TO: Memory Efficiently Rotate All Pages of a Multipage TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.tif";
        string outputPath = "output/output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                if (image is Aspose.Imaging.IMultipageImage multipageImage)
                {
                    multipageImage.PageExportingAction = delegate (int pageIndex, Aspose.Imaging.Image page)
                    {
                        ((Aspose.Imaging.RasterImage)page).Rotate(90f);
                    };

                    TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
                    image.Save(outputPath, options);
                }
                else
                {
                    TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
                    image.Save(outputPath, options);
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
 * 1. When a developer needs to rotate every page of a large multi‑page TIFF without loading the entire document into memory.
 * 2. When an application must process scanned documents page by page to apply transformations while keeping memory usage low.
 * 3. When converting legacy TIFF files that require orientation correction before archiving or further processing.
 * 4. When building a server‑side service that handles high‑resolution TIFFs and must avoid out‑of‑memory errors.
 * 5. When integrating Aspose.Imaging into a workflow that sequentially edits each frame of a multi‑page image, such as rotating pages for PDF generation.
 */
