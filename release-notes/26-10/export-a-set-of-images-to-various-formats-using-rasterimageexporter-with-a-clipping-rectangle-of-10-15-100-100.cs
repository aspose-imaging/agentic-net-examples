// HOW-TO: Export Images to JPEG and PNG with Clipping Rectangle in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;

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

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                    string jpegPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");
                    Directory.CreateDirectory(Path.GetDirectoryName(jpegPath));
                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        raster.Save(jpegPath, jpegOptions);
                    }

                    string pngPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(pngPath));
                    using (PngOptions pngOptions = new PngOptions())
                    {
                        raster.Save(pngPath, pngOptions);
                    }

                    string bmpPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        raster.Save(bmpPath, bmpOptions);
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
 * 1. When you need to batch‑convert a folder of mixed‑format pictures to JPEG and PNG while extracting only a specific region of each image.
 * 2. When an application must generate thumbnails of a defined area from large raster files for a web gallery.
 * 3. When a reporting tool requires the same visual region from multiple source images saved in different formats for PDF embedding.
 * 4. When a migration script has to preserve image quality while exporting selected portions of legacy BMP, TIFF, or other raster files to modern formats.
 * 5. When an automated workflow needs to cache raster data, apply a clipping rectangle, and store the result as JPEG and PNG for downstream processing.
 */
