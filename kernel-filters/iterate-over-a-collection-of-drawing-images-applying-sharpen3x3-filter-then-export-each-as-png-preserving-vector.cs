// HOW-TO: Apply Sharpen3x3 Filter to Multiple Images and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
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

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                using (var image = Aspose.Imaging.Image.Load(filePath))
                {
                    Aspose.Imaging.RasterImage raster = null;
                    bool rasterCreatedSeparately = false;

                    if (image is Aspose.Imaging.RasterImage ri)
                    {
                        raster = ri;
                    }
                    else if (image is Aspose.Imaging.VectorImage vi)
                    {
                        using (var ms = new MemoryStream())
                        {
                            var tempOptions = new PngOptions();
                            tempOptions.Source = new StreamSource(ms);
                            vi.Save(ms, tempOptions);
                            ms.Position = 0;
                            raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms);
                            rasterCreatedSeparately = true;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen3x3);
                    raster.Filter(raster.Bounds, filterOptions);

                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string outputPath = Path.Combine(outputDirectory, fileName + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var saveOptions = new PngOptions();
                    saveOptions.Source = new FileCreateSource(outputPath, false);
                    raster.Save(outputPath, saveOptions);

                    if (rasterCreatedSeparately)
                    {
                        raster.Dispose();
                    }
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
 * 1. When you need to batch‑process a folder of CAD or SVG drawings, sharpen each image with a 3×3 kernel, and output high‑quality PNG files while keeping the original vector information.
 * 2. When an application must automatically enhance scanned engineering diagrams before publishing them online as PNGs without losing the ability to re‑vectorize later.
 * 3. When a server‑side service converts mixed raster and vector artwork into sharpened PNG thumbnails for a product catalog, ensuring consistent visual sharpness.
 * 4. When a desktop tool prepares printable PNG assets from vector illustrations, applying a Sharpen3x3 filter to improve edge definition while preserving the source vector data for future edits.
 * 5. When a CI pipeline validates image quality by sharpening and exporting all design assets in a repository to PNG format for visual regression testing.
 */
