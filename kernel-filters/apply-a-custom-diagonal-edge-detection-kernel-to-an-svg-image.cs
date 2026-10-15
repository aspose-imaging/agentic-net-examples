// HOW-TO: Apply Custom Diagonal Edge Detection to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
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

            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Color.White
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;
                svgImage.Save(tempPngPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                double[,] customKernel = new double[,]
                {
                    { -1, 0, 0 },
                    { 0, 2, 0 },
                    { 0, 0, -1 }
                };

                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                raster.Filter(raster.Bounds, convOptions);
                raster.Save(outputPath);
            }

            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When you need to convert an SVG logo to a high‑contrast PNG for use in a UI that highlights diagonal edges.
 * 2. When you want to preprocess vector graphics with a custom edge‑detection filter before feeding them into a machine‑learning model.
 * 3. When an e‑commerce site requires product illustrations with emphasized outlines for better visual separation on thumbnails.
 * 4. When generating printable diagrams where diagonal edges must be accentuated to meet branding guidelines.
 * 5. When automating a batch workflow that rasterizes SVG icons and applies a custom convolution kernel to create stylized assets for a game.
 */
