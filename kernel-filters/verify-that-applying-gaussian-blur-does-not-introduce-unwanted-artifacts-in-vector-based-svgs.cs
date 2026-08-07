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
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output_blurred.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to a temporary PNG file
                string tempRasterPath = @"C:\temp\temp_raster.png";
                Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));

                var rasterOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    }
                };
                svgImage.Save(tempRasterPath, rasterOptions);

                // Load the rasterized PNG
                using (Image rasterImg = Image.Load(tempRasterPath))
                {
                    var raster = (RasterImage)rasterImg;

                    // Apply Gaussian blur filter
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the blurred image
                    raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to generate a blurred PNG thumbnail of an SVG logo for a web gallery while preserving the original vector file.
 * 2. When a developer wants to create a soft‑focused background image from a vector illustration to enhance the visual appeal of a UI layout.
 * 3. When a developer must apply a Gaussian blur to an SVG‑based map before overlaying it on a heat‑map to reduce visual clutter and improve readability.
 * 4. When a developer needs to convert an SVG diagram to a PNG with a blur effect for inclusion in a PDF report or presentation.
 * 5. When a developer is testing that applying a Gaussian blur filter to a rasterized SVG does not introduce unwanted artifacts before automating batch image processing.
 */