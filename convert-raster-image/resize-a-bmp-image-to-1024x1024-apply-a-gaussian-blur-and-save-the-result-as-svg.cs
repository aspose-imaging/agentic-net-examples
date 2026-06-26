using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cache data for performance
                if (!image.IsCached) image.CacheData();

                // Resize to 1024x1024
                image.Resize(1024, 1024);

                // Apply Gaussian blur
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare SVG save options with rasterization settings
                SvgOptions svgOptions = new SvgOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = new SizeF(1024, 1024)
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the result as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert legacy BMP assets into scalable SVG icons for a responsive web UI while ensuring a consistent 1024×1024 size and a soft blur effect.
 * 2. When an automation script must batch‑process scanned BMP documents, resize them to a standard dimension, apply a Gaussian blur to mask sensitive details, and store the results as SVG for lightweight preview rendering.
 * 3. When a game developer wants to generate blurred background textures from BMP source files, resize them to power‑of‑two dimensions, and embed them in SVG format for resolution‑independent UI overlays.
 * 4. When a reporting tool requires converting high‑resolution BMP charts into SVG vectors with a uniform size and a subtle blur to improve visual hierarchy in PDF exports.
 * 5. When a desktop application needs to import user‑provided BMP images, automatically resize them to 1024×1024, apply a Gaussian blur for artistic effect, and save as SVG to enable further vector‑based editing.
 */