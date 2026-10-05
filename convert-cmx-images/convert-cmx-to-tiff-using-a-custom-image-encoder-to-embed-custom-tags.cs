// HOW-TO: Convert CMX to TIFF with Custom Rasterization Options in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-28
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
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\result.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = cmx.Width,
                    PageHeight = cmx.Height
                };

                cmx.Save(outputPath, tiffOptions);
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
 * 1. When you need to display CorelDRAW CMX vector drawings in a TIFF viewer or document, you can convert them using Aspose.Imaging in C#.
 * 2. When a batch processing job must archive CMX files as lossless TIFF images for long‑term storage while preserving page dimensions.
 * 3. When integrating a .NET application with a printing workflow that only accepts TIFF, you can rasterize CMX artwork to TIFF on the fly.
 * 4. When generating thumbnails or previews for CMX designs, converting them to TIFF with a white background ensures consistent rendering across platforms.
 * 5. When a document management system requires TIFF files with specific page size metadata, you can use the vector rasterization options to match the original CMX dimensions.
 */
