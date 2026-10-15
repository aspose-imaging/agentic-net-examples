// HOW-TO: Batch Apply Emboss5x5 Filter to PNG Images with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_embossed.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    double[,] emboss5x5 = new double[,]
                    {
                        { -2, -1, 0, 1, 2 },
                        { -1, -1, 0, 1, 1 },
                        { 0, 0, 0, 0, 0 },
                        { 1, 1, 0, -1, -1 },
                        { 2, 1, 0, -1, -2 }
                    };

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(emboss5x5);
                    raster.Filter(raster.Bounds, filterOptions);

                    var saveOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, saveOptions);
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
 * 1. When you need to automatically add a 3‑D emboss effect to a large set of PNG assets for a game UI.
 * 2. When you want to preprocess product photos by applying a consistent emboss filter before uploading them to an e‑commerce site.
 * 3. When a desktop application must generate stylized thumbnails from user‑uploaded PNGs without manual editing.
 * 4. When a build pipeline should enhance documentation screenshots with an emboss effect as part of automated asset preparation.
 * 5. When you are creating a batch script to convert raw PNG scans into embossed images for artistic printing workflows.
 */
