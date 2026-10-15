// HOW-TO: Get BMP Image Width and Height in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                int width = raster.Width;
                int height = raster.Height;

                Console.WriteLine($"Width: {width}, Height: {height}");
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
 * 1. When you need to validate that an uploaded BMP file meets specific size requirements before further processing.
 * 2. When generating thumbnails or resizing images, you first need the original BMP dimensions to calculate scaling ratios.
 * 3. When integrating BMP images into a PDF or report, you must know the pixel width and height to position them correctly.
 * 4. When performing batch image analysis, retrieving each BMP's dimensions helps filter out images that are too small or too large.
 * 5. When logging or auditing image assets, capturing the BMP's width and height provides essential metadata for inventory tracking.
 */
