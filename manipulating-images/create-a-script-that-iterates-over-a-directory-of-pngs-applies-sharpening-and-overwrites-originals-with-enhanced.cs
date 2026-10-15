// HOW-TO: Batch Sharpen PNG Images and Overwrite Originals Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "PngImages";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (RasterImage raster = (RasterImage)Image.Load(filePath))
                {
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());
                    raster.Save(filePath, new PngOptions());
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
 * 1. When you need to improve the visual clarity of a large set of PNG photos before publishing them on a website.
 * 2. When an automated build process must apply a sharpening filter to every PNG asset in a folder to meet quality standards.
 * 3. When a desktop application has to replace existing PNG thumbnails with sharpened versions to enhance user experience.
 * 4. When a migration script has to batch‑process product images, applying sharpening and saving them back to the same file paths.
 * 5. When a content management system requires on‑the‑fly enhancement of uploaded PNG files without creating duplicate copies.
 */
