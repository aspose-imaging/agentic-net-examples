// HOW-TO: How To Apply Gaussian Blur To PNG And Convert SVG To PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // ---------- PNG processing ----------
            string pngInputPath = "input.png";
            string pngOutputPath = "output\\output_filtered.png";

            if (!File.Exists(pngInputPath))
            {
                Console.Error.WriteLine($"File not found: {pngInputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

            // Load PNG, apply Gaussian blur, and save
            using (RasterImage pngImage = (RasterImage)Image.Load(pngInputPath))
            {
                var blurOptions = new GaussianBlurFilterOptions();
                blurOptions.Radius = 5; // blur radius

                pngImage.Filter(pngImage.Bounds, blurOptions);

                var pngSaveOptions = new PngOptions();
                pngImage.Save(pngOutputPath, pngSaveOptions);
            }

            // ---------- SVG processing ----------
            string svgInputPath = "input.svg";
            string svgOutputPath = "output\\output_from_svg.png";

            if (!File.Exists(svgInputPath))
            {
                Console.Error.WriteLine($"File not found: {svgInputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(svgOutputPath));

            // Load SVG, rasterize to PNG, and save
            using (Image svgImage = Image.Load(svgInputPath))
            {
                var rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size; // match SVG size

                var pngSaveOptions = new PngOptions();
                pngSaveOptions.VectorRasterizationOptions = rasterOptions;

                svgImage.Save(svgOutputPath, pngSaveOptions);
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
 * 1. When you need to soften edges of a PNG photo before embedding it in a web page.
 * 2. When you must preprocess a PNG asset with a Gaussian blur to create a background effect for a UI theme.
 * 3. When you have an SVG logo and need a raster PNG version for email newsletters.
 * 4. When you want to generate thumbnail PNGs from vector SVG files while preserving the original dimensions.
 * 5. When an automated build pipeline must batch‑process PNGs and SVGs, applying a blur filter to PNGs and converting SVGs to PNGs for downstream services.
 */
