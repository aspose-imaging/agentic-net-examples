// HOW-TO: How To Convert Images To LZW Compressed TIFF And Check Size Reduction In C# (Aspose.Imaging for .NET)
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

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_lzw.tif");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
                    image.Save(outputPath, tiffOptions);
                }

                long originalSize = new FileInfo(inputPath).Length;
                long newSize = new FileInfo(outputPath).Length;

                if (newSize < originalSize)
                {
                    Console.WriteLine($"Reduced: {inputPath} ({originalSize} bytes) -> {outputPath} ({newSize} bytes)");
                }
                else
                {
                    Console.WriteLine($"No reduction: {inputPath} ({originalSize} bytes) -> {outputPath} ({newSize} bytes)");
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
 * 1. When you need to batch‑convert a folder of photos to LZW‑compressed TIFF files to reduce storage space while preserving image quality.
 * 2. When you want to generate archival‑ready TIFF images with lossless LZW compression for legal or medical records and verify they are smaller than the originals.
 * 3. When an application must automatically shrink scanned documents before uploading them to a document‑management system, using C# and Aspose.Imaging.
 * 4. When you are building a server‑side image pipeline that converts user‑uploaded JPEG or PNG files to TIFF with LZW compression and logs the size savings.
 * 5. When you need to compare original and compressed file sizes programmatically to decide whether to keep the compressed version in a backup workflow.
 */
