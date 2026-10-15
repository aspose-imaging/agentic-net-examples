// HOW-TO: Crop a BMP Image by Pixel Coordinates and Save in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.bmp";
        string outputPath = "output\\cropped.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.CacheData();

                var cropRect = new Rectangle(50, 30, 200, 150);
                image.Crop(cropRect);

                var options = new BmpOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to extract a specific area from a large BMP scan for a thumbnail or preview in a C# desktop application.
 * 2. When you must isolate a region of a bitmap map (e.g., a section of a floor plan) before sending it to a reporting service.
 * 3. When an automated batch process has to trim borders from scanned documents saved as BMP files using Aspose.Imaging.
 * 4. When a game development tool requires cutting sprite sheets stored in BMP format into individual frames programmatically.
 * 5. When a legacy system stores images as BMP and you need to programmatically crop a region for further analysis or OCR.
 */
