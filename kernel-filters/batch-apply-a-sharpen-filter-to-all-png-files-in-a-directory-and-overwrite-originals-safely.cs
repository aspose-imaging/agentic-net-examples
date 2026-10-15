// HOW-TO: Batch Sharpen All PNG Images In A Folder Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
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
            string inputDirectory = "Input";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string filePath in files)
            {
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
 * 1. When you need to improve the clarity of a large set of PNG photos before publishing them on a website.
 * 2. When an automated build process must apply a sharpening effect to every PNG asset in a resource folder without manual editing.
 * 3. When you want to enhance scanned PNG documents in bulk to make text and details more readable.
 * 4. When a desktop application must refresh all product‑image PNGs with a consistent sharpen filter during a nightly maintenance job.
 * 5. When you are preparing PNG graphics for print and need to ensure each file is sharpened while preserving the original file names.
 */
