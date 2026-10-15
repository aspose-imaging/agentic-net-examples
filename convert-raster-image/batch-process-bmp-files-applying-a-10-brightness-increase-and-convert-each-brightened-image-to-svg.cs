// HOW-TO: Batch Increase BMP Brightness and Convert to SVG in C# (Aspose.Imaging for .NET)
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
            string inputFolder = "input";
            string outputFolder = "output";

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");
            foreach (string inputPath in bmpFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    if (!raster.IsCached) raster.CacheData();
                    raster.AdjustBrightness(25);

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".svg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = raster.Width,
                            PageHeight = raster.Height
                        }
                    };

                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to automatically brighten a collection of legacy BMP graphics before converting them to scalable SVG for web display.
 * 2. When a desktop application must process user‑uploaded BMP photos, enhance their visibility, and store them as vector files for further editing.
 * 3. When a batch job has to prepare BMP assets for printing by increasing brightness and converting them to SVG to retain resolution independence.
 * 4. When migrating an old image repository to a modern format, you can brighten each BMP and generate SVG equivalents in one automated step.
 * 5. When generating icons from BMP sources for a responsive UI, you may want to boost contrast and output SVG files for crisp scaling.
 */
