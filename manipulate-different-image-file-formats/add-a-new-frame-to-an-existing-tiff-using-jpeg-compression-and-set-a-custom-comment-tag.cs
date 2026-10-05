// HOW-TO: Add JPEG Compressed Frame to Existing TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output/output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int width = tiff.Width;
                int height = tiff.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffJpegRgb);
                TiffFrame newFrame = new TiffFrame(tiffOptions, width, height);

                Color[] whitePixels = Enumerable.Repeat(Color.White, width * height).ToArray();
                newFrame.SavePixels(newFrame.Bounds, whitePixels);

                tiff.AddFrame(newFrame);
                tiff.Save(outputPath);
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
 * 1. When you need to append a new JPEG‑compressed page to a multi‑page TIFF archive generated from scanned documents.
 * 2. When you want to create a blank white page in a TIFF file for later annotation or stamping in a C# imaging workflow.
 * 3. When a medical imaging system must add an additional image layer to a DICOM‑derived TIFF while preserving JPEG compression for size efficiency.
 * 4. When a digital archiving solution requires inserting a placeholder frame into an existing TIFF before merging it with other image assets.
 * 5. When a GIS application programmatically expands a geospatial TIFF stack with a new raster layer using Aspose.Imaging for .NET.
 */
