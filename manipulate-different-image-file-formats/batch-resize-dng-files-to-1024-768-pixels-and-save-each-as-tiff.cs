// HOW-TO: Batch Resize DNG Images to 1024x768 and Convert to TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add DNG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.dng", SearchOption.TopDirectoryOnly);

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                    raster.Resize(1024, 768, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileName + ".tiff");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to prepare raw DNG photos for a printing workflow that requires TIFF files at a fixed 1024×768 resolution.
 * 2. When you want to automatically downscale a large collection of DNG images to 1024×768 for faster web preview generation.
 * 3. When a digital archiving system must store raw camera files as uniformly sized TIFFs to ensure consistent metadata handling.
 * 4. When you are building a batch processing tool that converts DSLR DNG files into TIFF for compatibility with legacy image editors.
 * 5. When you need to reduce the file size of raw images while preserving enough detail for machine‑learning models that accept TIFF inputs.
 */
