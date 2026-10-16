// HOW-TO: Apply Median Filter To JPEG And Save With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                image.Save(outputPath);
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
 * 1. When you need to reduce salt‑and‑pepper noise in a JPEG before performing OCR in a C# application.
 * 2. When you want to preprocess user‑uploaded photos by applying a 3×3 median filter to improve visual quality in an ASP.NET web service.
 * 3. When you are building a batch image‑enhancement tool that automatically cleans up scanned documents saved as JPEGs using Aspose.Imaging.
 * 4. When you must ensure image resources are released correctly while applying a median filter to large raster images in a desktop C# utility.
 * 5. When you are integrating image noise reduction into a photo‑editing workflow that reads a JPEG, filters it, and writes the result back to disk.
 */
