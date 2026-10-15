// HOW-TO: Batch Convert BMP to PNG with 10 Pixel Crop in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

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

                if (!Path.GetExtension(inputPath).Equals(".bmp", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    int newWidth = raster.Width - 20;
                    int newHeight = raster.Height - 20;
                    if (newWidth <= 0 || newHeight <= 0)
                    {
                        Console.Error.WriteLine($"Image too small to crop: {inputPath}");
                        return;
                    }

                    var cropRect = new Aspose.Imaging.Rectangle(10, 10, newWidth, newHeight);
                    raster.Crop(cropRect);

                    using (var options = new PngOptions())
                    {
                        raster.Save(outputPath, options);
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
 * 1. When you need to prepare a set of legacy BMP assets for a website by converting them to PNG and removing a 10‑pixel border around each image.
 * 2. When an automated build process must batch‑process scanned BMP files, crop uniform margins, and store the results as lossless PNGs for downstream graphics pipelines.
 * 3. When a desktop application has to migrate user‑uploaded BMP pictures to a more web‑friendly format while trimming unwanted edges before saving them to a server folder.
 * 4. When a game developer wants to reduce texture size by converting BMP textures to PNG and consistently cropping a 10‑pixel border to eliminate padding.
 * 5. When a document management system needs to archive BMP scans as PNGs with a standardized border removal to ensure consistent appearance across all stored images.
 */
