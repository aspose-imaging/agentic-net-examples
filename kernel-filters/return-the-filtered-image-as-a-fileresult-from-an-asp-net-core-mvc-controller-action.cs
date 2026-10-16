// HOW-TO: Apply Gaussian Blur To JPEG And Save With Quality In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

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
                var rect = new Rectangle(0, 0, image.Width, image.Height);
                var filterOptions = new GaussianBlurFilterOptions(5, 1.0);
                image.Filter(rect, filterOptions);

                var source = new FileCreateSource(outputPath, false);
                var options = new JpegOptions { Source = source, Quality = 90 };
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
 * 1. When you need to automatically blur user‑uploaded photos before storing them on the server to protect privacy.
 * 2. When you want to generate a soft‑focus preview of a high‑resolution JPEG for a web gallery using Aspose.Imaging in C#.
 * 3. When an e‑commerce site must apply a Gaussian blur watermark effect to product images before delivering them via an ASP.NET Core controller.
 * 4. When a medical imaging application requires smoothing of scanned JPEG images to reduce noise before analysis.
 * 5. When a content‑management system needs to resize and compress JPEGs with a blur filter and return them as a FileResult in a .NET MVC action.
 */
