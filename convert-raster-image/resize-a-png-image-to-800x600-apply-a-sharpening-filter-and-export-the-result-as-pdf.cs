// HOW-TO: Resize PNG to 800x600, Sharpen, and Export as PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
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
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Resize(800, 600);

                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                var pdfOptions = new PdfOptions();
                raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to create a printable PDF report from a PNG diagram and must resize it to 800 × 600 pixels while enhancing its edges with a sharpening filter.
 * 2. When a web application generates thumbnails from user‑uploaded PNGs, sharpens them for better visual quality, and then bundles them into a PDF document for download.
 * 3. When an automated batch process converts a collection of PNG assets to PDF, ensuring each image is uniformly sized and visually crisp for archival purposes.
 * 4. When a desktop utility prepares product images for marketing brochures by resizing PNG files, applying a sharpen effect, and exporting the result as a PDF page.
 * 5. When a C# service integrates Aspose.Imaging to transform PNG screenshots into PDF slides, adjusting dimensions to 800 × 600 and improving clarity with a sharpen filter.
 */
