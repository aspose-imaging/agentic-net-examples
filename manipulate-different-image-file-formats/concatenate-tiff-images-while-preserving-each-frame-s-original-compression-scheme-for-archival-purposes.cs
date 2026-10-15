// HOW-TO: Merge Multiple TIFF Files While Keeping Original Compression in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "input1.tif";
            string inputPath2 = "input2.tif";
            string outputPath = "output\\merged.tif";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage dest = (TiffImage)Image.Load(inputPath1))
            {
                using (TiffImage src = (TiffImage)Image.Load(inputPath2))
                {
                    foreach (TiffFrame frame in src.Frames)
                    {
                        dest.AddFrame(TiffFrame.CopyFrame(frame));
                    }
                }

                dest.Save(outputPath);
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
 * 1. When you need to combine scanned documents stored as separate multi‑page TIFF files into a single archival TIFF without re‑encoding the original LZW or CCITT compression.
 * 2. When a medical imaging system must merge patient X‑ray TIFF series while preserving the lossless compression for regulatory compliance.
 * 3. When a GIS application has multiple tiled TIFF raster layers that must be concatenated into one file while keeping each layer’s original compression intact.
 * 4. When a digital preservation workflow requires appending newly scanned TIFF pages to an existing archive without degrading image quality.
 * 5. When a batch process creates a combined TIFF report from several source TIFFs and you want to retain each frame’s original compression to minimize file size.
 */
