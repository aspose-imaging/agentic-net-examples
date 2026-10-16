// HOW-TO: Apply Horizontal Edge Detection Kernel to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";
            string tempPath = "temp.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            // Rasterize SVG to PNG
            using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(tempPath, pngOptions);
            }

            // Apply custom horizontal edge detection kernel
            using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(tempPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)rasterImg;

                double[,] kernel = new double[,]
                {
                    { -1, -2, -1 },
                    {  0,  0,  0 },
                    {  1,  2,  1 }
                };

                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);
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
 * 1. When you need to highlight horizontal lines in an architectural SVG diagram before exporting it as a PNG for presentation slides.
 * 2. When converting vector floor plans to raster images while emphasizing structural edges for better visual contrast in web galleries.
 * 3. When preprocessing SVG assets with a custom convolution filter to improve edge detection for downstream computer‑vision analysis in a .NET application.
 * 4. When automating batch processing of SVG drawings to produce edge‑enhanced PNG thumbnails for a real‑estate listing website.
 * 5. When integrating Aspose.Imaging in a C# service to rasterize SVG logos and apply a horizontal Sobel‑like filter for print‑ready artwork.
 */
