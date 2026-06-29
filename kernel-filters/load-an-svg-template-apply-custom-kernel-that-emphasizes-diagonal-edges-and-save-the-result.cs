using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.svg";
            string tempPath = "temp\\temp.png";
            string outputPath = "output\\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure directories exist for temporary and output files
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = svgImage.Size }
                };
                svgImage.Save(tempPath, pngOptions);
            }

            // Load the rasterized PNG, apply custom convolution filter, and save the result
            using (Image rasterImage = Image.Load(tempPath))
            {
                RasterImage raster = (RasterImage)rasterImage;

                // Custom kernel emphasizing diagonal edges
                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    {  0, 0, 0 },
                    {  1, 0, -1 }
                };

                var convOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, convOptions);

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert an SVG logo into a PNG thumbnail while highlighting diagonal edges for a sharper UI icon.
 * 2. When a web application must generate raster images from vector diagrams and apply a custom edge‑detection filter to emphasize structural lines in reports.
 * 3. When an e‑commerce platform wants to automatically create product‑image watermarks that accentuate diagonal patterns for brand consistency.
 * 4. When a scientific visualization tool requires preprocessing of SVG charts into PNGs with a diagonal‑edge convolution to improve feature detection in downstream analysis.
 * 5. When a desktop publishing software needs to rasterize SVG artwork and apply a custom kernel to enhance diagonal details before exporting the final PNG asset.
 */