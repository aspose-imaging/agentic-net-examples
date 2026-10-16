// HOW-TO: Apply Emboss 5x5 Filter to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "templates/input.svg";
            string outputPath = "output/embossed.png";
            string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_raster.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load SVG and rasterize to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load rasterized image
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                // Apply Emboss5x5 filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                // Save the filtered image
                var outOptions = new PngOptions();
                raster.Save(outputPath, outOptions);
            }

            // Clean up temporary file
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
 * 1. When you need to convert a vector SVG logo into a raster PNG with an embossed 3‑D effect for web thumbnails.
 * 2. When generating product catalog images where the original SVG artwork must be stylized with a depth‑enhancing filter before publishing.
 * 3. When creating printable marketing assets that require a PNG version of an SVG diagram with a subtle emboss to improve visual contrast.
 * 4. When building an automated pipeline that processes SVG icons, applies a convolution emboss filter, and stores the results as PNG files for mobile apps.
 * 5. When developing a C# utility that rasterizes SVG illustrations and adds a predefined Emboss5x5 filter to match a brand’s textured graphic style.
 */
