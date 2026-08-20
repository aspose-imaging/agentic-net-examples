// HOW-TO: Apply Custom Soft Edge Vignette Kernel to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output\\result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    var rasterOptions = new SvgRasterizationOptions();
                    rasterOptions.PageSize = svgImage.Size;
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image as RasterImage
                    using (Image rasterImageContainer = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        // Define a custom soft‑edge kernel for vignette effect
                        double[,] kernel = new double[,]
                        {
                            { 0.5, 0.75, 0.5 },
                            { 0.75, 1.0, 0.75 },
                            { 0.5, 0.75, 0.5 }
                        };

                        // Apply convolution filter with the custom kernel
                        var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        rasterImage.Filter(rasterImage.Bounds, convOptions);

                        // Save the processed image as PNG
                        rasterImage.Save(outputPath, new PngOptions());
                    }
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
 * 1. When you need to add a subtle vignette border to an SVG logo before exporting it as a high‑resolution PNG for web use.
 * 2. When a desktop application must convert vector illustrations to raster images with a soft‑edge effect to match a brand’s visual style.
 * 3. When generating thumbnails of SVG diagrams that require a gentle darkening around the edges to improve focus in a reporting dashboard.
 * 4. When automating batch processing of SVG assets to produce PNG assets with a custom convolution kernel for consistent UI theming.
 * 5. When integrating Aspose.Imaging into a C# service that applies a custom soft‑edge filter to user‑uploaded SVG files before storing them as PNGs.
 */
