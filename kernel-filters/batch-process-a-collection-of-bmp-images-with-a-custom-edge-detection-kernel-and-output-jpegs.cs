// HOW-TO: Batch Convert BMP Images to JPEG with Custom Edge Detection in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                if (!string.Equals(Path.GetExtension(inputPath), ".bmp", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                string outputPath = Path.Combine(outputDirectory, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                double[,] customKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel));
                    JpegOptions jpegOptions = new JpegOptions();
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
 * 1. When you need to automatically apply an edge‑detect filter to a folder of BMP photos and save the results as compressed JPEG files for web publishing.
 * 2. When a legacy system stores scanned documents as BMP and you must convert them to JPEG while highlighting outlines for OCR preprocessing.
 * 3. When a desktop application must process thousands of BMP assets, detect edges using a custom convolution kernel, and output JPEGs for faster loading in a UI.
 * 4. When you want to integrate Aspose.Imaging into a C# batch job that transforms BMP graphics into JPEG thumbnails with edge enhancement for visual inspection.
 * 5. When a reporting tool requires BMP charts to be edge‑enhanced and stored as JPEGs to reduce file size before emailing to stakeholders.
 */
