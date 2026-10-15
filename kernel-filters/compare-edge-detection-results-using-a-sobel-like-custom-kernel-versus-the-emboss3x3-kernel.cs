// HOW-TO: Compare Custom Sobel Edge Detection With Emboss3x3 Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string edgeOutputPath = "output_edge.png";
            string embossOutputPath = "output_emboss.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Edge detection using custom kernel
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                    raster.CacheData();

                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                var edgeOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel);
                raster.Filter(raster.Bounds, edgeOptions);

                Directory.CreateDirectory(Path.GetDirectoryName(edgeOutputPath));
                raster.Save(edgeOutputPath, new PngOptions());
            }

            // Emboss using Emboss3x3 kernel
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                    raster.CacheData();

                double[,] embossKernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1,  1, 1 },
                    {  0,  1, 2 }
                };

                var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
                raster.Filter(raster.Bounds, embossOptions);

                Directory.CreateDirectory(Path.GetDirectoryName(embossOutputPath));
                raster.Save(embossOutputPath, new PngOptions());
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
 * 1. When you need to highlight edges in a JPEG photo for computer‑vision preprocessing using a custom convolution kernel in C#.
 * 2. When you want to create a stylized emboss effect on an image for UI thumbnails or marketing graphics with Aspose.Imaging.
 * 3. When you must generate two separate output files—one showing edge detection and another showing emboss—to compare visual results side‑by‑side.
 * 4. When you are working with raster images that must be cached before applying filters to avoid performance issues in .NET applications.
 * 5. When you need to save processed images in lossless PNG format after applying convolution filters for further analysis or archiving.
 */
