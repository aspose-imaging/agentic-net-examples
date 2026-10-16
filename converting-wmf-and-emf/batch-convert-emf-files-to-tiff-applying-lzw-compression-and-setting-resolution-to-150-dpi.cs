// HOW-TO: Batch Convert EMF to TIFF with LZW Compression and 150 DPI in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".tiff");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb))
                    {
                        tiffOptions.Compression = TiffCompressions.Lzw;
                        tiffOptions.Xresolution = new TiffRational(150, 1);
                        tiffOptions.Yresolution = new TiffRational(150, 1);

                        VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        };
                        tiffOptions.VectorRasterizationOptions = vectorOptions;

                        image.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive a collection of EMF illustrations as smaller, loss‑less TIFF files for long‑term storage.
 * 2. When preparing vector graphics for high‑quality printing, you convert EMF to TIFF with 150 DPI to meet printer resolution requirements.
 * 3. When a document‑management system only accepts raster images, you batch convert EMF diagrams to LZW‑compressed TIFF to keep file size low.
 * 4. When feeding scanned drawings into an OCR engine, you standardize the resolution to 150 DPI by converting EMF to TIFF.
 * 5. When migrating legacy CAD assets to a GIS platform, you transform EMF files into TIFF with LZW compression for faster loading and consistent raster format.
 */
