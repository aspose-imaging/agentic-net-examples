// HOW-TO: Apply Emboss5x5 Filter to SVG Icon and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options for SVG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = ((SvgImage)image).Size
                };

                // Set up PNG save options with rasterization
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImage = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImage;

                        // Apply Emboss5x5 convolution filter
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                        // Save the filtered image as PNG
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to sharpen the edges of a vector‑based icon for a UI without changing its colors, you can rasterize the SVG and apply an Emboss5x5 filter before exporting to PNG.
 * 2. When generating high‑contrast thumbnails for a web catalog, applying an emboss filter to SVG graphics ensures the lines stand out after conversion to raster images.
 * 3. When preparing SVG logos for print or PDF embedding, embossing the rasterized version improves line definition while keeping the original vector shape intact.
 * 4. When creating stylized assets for a game UI, developers can use this code to convert SVG assets to PNG with enhanced edge detail via the Emboss5x5 convolution.
 * 5. When automating a batch process that converts design icons to PNG with a subtle 3‑D effect, the Emboss5x5 filter provides a quick way to add depth without manual editing.
 */
