// HOW-TO: Batch Sharpen All PNG Images in a Folder Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

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

                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + "_sharpened.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    double[,] sharpenKernel = new double[,]
                    {
                        {  0, -1,  0 },
                        { -1,  5, -1 },
                        {  0, -1,  0 }
                    };

                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(sharpenKernel));
                    raster.Save(outputPath);
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
 * 1. When you need to automatically enhance the clarity of dozens of product photos stored as PNGs before uploading them to an e‑commerce site.
 * 2. When a desktop application must improve the sharpness of scanned documents in a folder to make text more readable.
 * 3. When a server‑side service processes user‑uploaded PNG screenshots and applies a sharpening filter to prepare them for archival.
 * 4. When a batch script is required to sharpen PNG assets for a game’s UI without manually opening each file.
 * 5. When you want to integrate Aspose.Imaging into a C# build pipeline to apply a predefined convolution kernel to all PNG files in a directory.
 */
