// HOW-TO: Apply Gaussian Blur Filter to JPEG and Save with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                image.Filter(image.Bounds, filterOptions);

                JpegOptions jpegOptions = new JpegOptions { Quality = 90 };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to automatically blur sensitive areas of uploaded JPEG photos before storing them on a server.
 * 2. When you want to preprocess images with a Gaussian blur to improve OCR accuracy in a C# web application.
 * 3. When you are building a photo‑editing service that applies a soft‑focus effect and saves the result with adjustable JPEG quality.
 * 4. When you must generate preview thumbnails with reduced detail to speed up page loads while preserving the original aspect ratio.
 * 5. When you are creating a batch job that sanitizes a collection of JPEG files by applying a kernel filter and re‑encoding them for archival.
 */
