// HOW-TO: Compare Emboss3x3 Vs Emboss5x5 Filter Quality On SVG In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string tempRasterPath = "temp.png";
        string outputPath3 = "output_emboss3.png";
        string outputPath5 = "output_emboss5.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath5) ?? ".");

            // Load SVG and rasterize to PNG
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("Input file is not an SVG image.");
                    return;
                }

                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    };
                    image.Save(tempRasterPath, pngOptions);
                }
            }

            // Apply Emboss3x3 filter
            using (RasterImage raster3 = (RasterImage)Image.Load(tempRasterPath))
            {
                raster3.Filter(raster3.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                using (PngOptions outOptions = new PngOptions())
                {
                    raster3.Save(outputPath3, outOptions);
                }
            }

            // Apply Emboss5x5 filter
            using (RasterImage raster5 = (RasterImage)Image.Load(tempRasterPath))
            {
                raster5.Filter(raster5.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
                using (PngOptions outOptions = new PngOptions())
                {
                    raster5.Save(outputPath5, outOptions);
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
 * 1. When a developer needs to evaluate which emboss filter (3x3 or 5x5) yields sharper edges on rasterized SVG graphics before selecting one for a web thumbnail generator.
 * 2. When a developer wants to benchmark the visual impact of 3x3 and 5x5 emboss kernels on SVG icons that are converted to PNG for a UI component library.
 * 3. When a developer must generate side‑by‑side PNG samples of the same SVG processed with different convolution filters to present to a design team.
 * 4. When a developer is automating image preprocessing to decide the optimal emboss filter for printing high‑resolution SVG artwork.
 * 5. When a developer is creating a unit test that verifies the consistency of Aspose.Imaging’s Emboss3x3 and Emboss5x5 filters on identical input files.
 */
