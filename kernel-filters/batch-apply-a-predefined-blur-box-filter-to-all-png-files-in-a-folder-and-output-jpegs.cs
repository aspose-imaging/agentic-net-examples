// HOW-TO: Batch Apply Blur Filter to PNG Images and Save as JPEG in C# (Aspose.Imaging for .NET)
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
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    double[,] blurKernel = new double[,]
                    {
                        { 0.04, 0.04, 0.04, 0.04, 0.04 },
                        { 0.04, 0.04, 0.04, 0.04, 0.04 },
                        { 0.04, 0.04, 0.04, 0.04, 0.04 },
                        { 0.04, 0.04, 0.04, 0.04, 0.04 },
                        { 0.04, 0.04, 0.04, 0.04, 0.04 }
                    };

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(blurKernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    var jpegOptions = new JpegOptions
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
 * 1. When you need to automatically blur confidential details in a collection of PNG screenshots before archiving them as smaller JPEG files.
 * 2. When you want to preprocess product photos by applying a uniform blur and converting them to JPEG for faster web page loading.
 * 3. When you must generate preview thumbnails with a soft focus effect from high‑resolution PNG assets and store them as JPEGs for email attachments.
 * 4. When you are building a batch image pipeline that removes sharp edges from PNG diagrams and saves the results in JPEG format for legacy systems.
 * 5. When you need to apply the same convolution blur to every PNG in a folder and output compressed JPEGs for batch reporting or documentation.
 */
