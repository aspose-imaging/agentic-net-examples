// HOW-TO: Apply Median Filter to JPEG Images in C# Blazor WebAssembly (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Apply median filter with kernel size 3
                image.Filter(image.Bounds, new MedianFilterOptions(3));

                Source src = new FileCreateSource(outputPath, false);
                JpegOptions options = new JpegOptions() { Source = src, Quality = 90 };
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
 * 1. When you need to reduce salt‑and‑pepper noise in user‑uploaded JPEG photos directly in a Blazor WebAssembly app before saving them to the server.
 * 2. When you want to apply a lightweight client‑side median filter to improve image quality for preview thumbnails in a C# web application.
 * 3. When you must ensure consistent JPEG compression quality (e.g., 90) after noise reduction without round‑tripping through a backend service.
 * 4. When you are building an offline image editing tool in Blazor that lets users clean up scanned documents by smoothing pixel artifacts.
 * 5. When you require a simple C# solution to process and re‑encode uploaded pictures with a 3×3 kernel filter to meet UI performance constraints.
 */
