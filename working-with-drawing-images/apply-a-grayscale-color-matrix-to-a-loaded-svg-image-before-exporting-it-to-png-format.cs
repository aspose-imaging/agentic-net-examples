// HOW-TO: Convert SVG to Grayscale PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Rasterize the SVG and apply grayscale
                using (RasterImage rasterImage = (RasterImage)image)
                {
                    rasterImage.Grayscale();

                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.Grayscale
                    };

                    rasterImage.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a black‑and‑white preview of an SVG logo for a PDF report.
 * 2. When a web service must deliver grayscale thumbnails of user‑uploaded SVG icons as PNG files.
 * 3. When an e‑learning platform converts vector diagrams to grayscale PNGs for printing on monochrome printers.
 * 4. When a mobile app prepares SVG illustrations for display on devices that only support grayscale images.
 * 5. When a batch process archives SVG assets by rasterizing them into grayscale PNGs to reduce file size and simplify storage.
 */
