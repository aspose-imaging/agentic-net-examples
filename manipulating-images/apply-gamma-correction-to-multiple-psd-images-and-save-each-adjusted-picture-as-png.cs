// HOW-TO: Batch Apply Gamma Correction to PSD Files and Save as PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "C:\\InputPsds";
            string outputFolder = "C:\\OutputPngs";

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string[] psdFiles = Directory.GetFiles(inputFolder, "*.psd");

            foreach (string inputPath in psdFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    raster.AdjustGamma(1.2f);

                    PngOptions pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to improve the brightness and contrast of a collection of Photoshop PSD files before publishing them as web‑ready PNG images.
 * 2. When an automated pipeline must convert multiple PSD assets to PNG while applying a consistent gamma boost for uniform visual appearance across devices.
 * 3. When a desktop application processes user‑uploaded PSD files, adjusts their gamma to match brand guidelines, and stores the results as PNG thumbnails.
 * 4. When a batch script prepares marketing graphics by correcting gamma on all PSD files in a folder and exporting them to PNG for faster loading on websites.
 * 5. When a CI/CD build step validates design assets by applying gamma correction to PSDs and generating PNGs for visual regression testing.
 */
