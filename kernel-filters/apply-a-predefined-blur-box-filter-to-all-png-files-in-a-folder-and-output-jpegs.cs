// HOW-TO: Apply Blur Box Filter to PNGs and Save as JPEGs in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
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
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                double[,] blurBoxKernel = new double[,]
                {
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 }
                };

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(blurBoxKernel));

                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to batch‑process a collection of PNG assets to add a soft blur before converting them to JPEG for faster web loading.
 * 2. When you want to generate blurred preview images from high‑resolution PNGs for use in galleries or slideshows.
 * 3. When you must prepare PNG screenshots with a uniform blur effect and store them as JPEGs to reduce file size for email attachments.
 * 4. When an application requires converting user‑uploaded PNG files to JPEG while applying a predefined blur kernel for privacy masking.
 * 5. When automating a nightly job that applies a box blur to all PNG files in a folder and outputs JPEGs for downstream image‑analysis pipelines.
 */
