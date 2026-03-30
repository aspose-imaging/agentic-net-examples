using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string tempPath = @"C:\Images\temp.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist (called before any Save)
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // ------------------------------------------------------------
        // 1. Load the SVG and rasterize it to a temporary PNG file
        // ------------------------------------------------------------
        using (Image svgImage = Image.Load(inputPath))
        {
            // Set up rasterization options – use the original SVG size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // PNG save options that reference the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image to a temporary PNG file
            svgImage.Save(tempPath, pngOptions);
        }

        // Verify the temporary raster file was created
        if (!File.Exists(tempPath))
        {
            Console.Error.WriteLine($"Failed to create intermediate file: {tempPath}");
            return;
        }

        // ------------------------------------------------------------
        // 2. Load the raster PNG, resize it, apply Gaussian blur, and save
        // ------------------------------------------------------------
        using (Image rasterImage = Image.Load(tempPath))
        {
            // Resize to a smaller size (e.g., 50% of original)
            rasterImage.Resize(rasterImage.Width / 2, rasterImage.Height / 2);

            // Cast to RasterImage to access filtering capabilities
            var raster = (RasterImage)rasterImage;

            // Apply Gaussian blur with kernel size 5 and sigma 4.0
            var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
            raster.Filter(raster.Bounds, blurOptions);

            // Save the final blurred image
            raster.Save(outputPath);
        }
    }
}