// HOW-TO: Apply Custom Diagonal Edge Detection to SVG and Export as PNG in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Prepare rasterization options for PNG output
                var svgRasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = svgRasterOptions
                };

                // Rasterize SVG to a memory stream
                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized PNG as a RasterImage
                    using (Image rasterImageContainer = Image.Load(ms))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        // Define a custom diagonal edge‑detection kernel
                        double[,] kernel = new double[,]
                        {
                            { -1, 0, 1 },
                            {  0, 0, 0 },
                            {  1, 0,-1 }
                        };

                        // Create convolution filter options with the custom kernel
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                        // Apply the filter to the entire image
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        // Save the filtered image as PNG
                        rasterImage.Save(outputPath);
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
 * 1. When you need to highlight diagonal edges in a vector logo by converting the SVG to a PNG with a custom convolution filter.
 * 2. When generating thumbnails for a web gallery that require edge‑enhanced previews of SVG illustrations.
 * 3. When preprocessing SVG diagrams for computer‑vision algorithms that expect raster images with emphasized diagonal features.
 * 4. When creating stylized graphics for print media where a diagonal edge‑detect effect must be applied before saving as PNG.
 * 5. When automating batch conversion of SVG assets to PNG while applying a custom kernel to improve visual contrast for UI mockups.
 */
