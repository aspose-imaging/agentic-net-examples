// HOW-TO: Batch Apply Median Filter to Raster Images and Save as SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputFolder = "input";
        string outputFolder = "output";

        try
        {
            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            var files = Directory.GetFiles(inputFolder);
            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(file) + ".svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(file))
                {
                    var raster = image as Aspose.Imaging.RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Not a raster image: {file}");
                        continue;
                    }

                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                    raster.Save(outputPath, new SvgOptions());
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
 * 1. When you need to clean up noise in a collection of photos before converting them to scalable vector graphics for web display.
 * 2. When you want to automate processing of scanned documents, applying a median filter to improve readability and then export each page as an SVG file.
 * 3. When you are preparing a batch of raster icons for inclusion in a UI library and require a uniform smoothing filter before vectorizing them.
 * 4. When you must integrate image preprocessing into a C# pipeline that reads images from a folder, applies noise reduction, and outputs SVGs for further editing in design tools.
 * 5. When you are building a server‑side service that receives raster uploads, denoises them with a median filter, and returns lightweight SVG representations for responsive applications.
 */
