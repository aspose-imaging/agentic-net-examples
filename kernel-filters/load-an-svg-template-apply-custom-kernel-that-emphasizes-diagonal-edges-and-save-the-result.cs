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
            // Hardcoded input and output paths
            string inputPath = "template.svg";
            string outputPath = "result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary rasterized PNG path
            string tempPath = Path.Combine(Path.GetTempPath(), "temp_raster.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            // Load SVG and rasterize to temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(tempPath, pngOptions);
            }

            // Load raster image, apply custom convolution kernel, and save final result
            using (Image rasterImage = Image.Load(tempPath))
            {
                var raster = (RasterImage)rasterImage;

                // Custom kernel emphasizing diagonal edges
                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    {  0, 0, 0 },
                    {  1, 0,-1 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
                raster.Save(outputPath, new PngOptions());
            }

            // Clean up temporary file
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
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
 * 1. When a developer wants to convert an SVG logo into a PNG thumbnail with enhanced diagonal edge detection for sharper visual emphasis.
 * 2. When a web application needs to generate raster images from vector icons and apply a custom convolution filter to highlight diagonal lines before serving them to browsers.
 * 3. When an automated reporting tool must embed vector diagrams as PNGs with edge‑enhanced styling to improve readability in printed PDFs.
 * 4. When a game asset pipeline requires converting SVG assets to PNG textures and applying a diagonal edge kernel to create stylized outlines for in‑game UI elements.
 * 5. When a data‑visualization service processes SVG charts, rasterizes them, and emphasizes diagonal trends using a custom convolution filter before exporting the final PNG chart.
 */