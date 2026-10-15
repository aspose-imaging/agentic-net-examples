// HOW-TO: Convert CorelDRAW CDR to LZW Compressed TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output\\output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw,
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };

                cdr.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to generate lossless, LZW‑compressed TIFF files from legacy CorelDRAW artwork for archival or printing pipelines.
 * 2. When an application must batch‑process CDR designs and output them as TIFF images that retain original dimensions while reducing file size.
 * 3. When integrating a .NET service that converts vector CDR files to raster TIFFs for compatibility with systems that only accept TIFF input.
 * 4. When creating a workflow that extracts pages from multi‑page CorelDRAW files and saves each page as a high‑quality TIFF with LZW compression.
 * 5. When building a document management solution that stores uploaded CDR files as compressed TIFFs to save storage space without sacrificing image fidelity.
 */
