using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

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
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG -> raster conversion
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Prepare PNG options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG into a memory stream
                using (var memoryStream = new MemoryStream())
                {
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image as a RasterImage
                    using (Image rasterImageContainer = Image.Load(memoryStream))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageContainer;

                        // Define a 3x3 custom kernel (central weight 0.333..., surrounding 0.08333...)
                        double[,] kernel = new double[,]
                        {
                            { 0.0833333333, 0.0833333333, 0.0833333333 },
                            { 0.0833333333, 0.3333333333, 0.0833333333 },
                            { 0.0833333333, 0.0833333333, 0.0833333333 }
                        };

                        // Create convolution filter options (factor = 1.0, bias = 0)
                        var filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);

                        // Apply the filter to the entire image
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        // Save the filtered raster image to the output path
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
 * 1. When a developer needs to apply a lightweight blur to vector icons stored as SVG before converting them to PNG for use in a web UI, they can define a custom kernel with a central weight of 0.5 and surrounding weights of 0.125, normalize it, and filter the rasterized image.
 * 2. When generating high‑resolution product catalogs, a developer may want to soften the edges of SVG illustrations to avoid harsh aliasing after rasterization, using the custom kernel to smooth the image before saving as PNG.
 * 3. When creating thumbnail previews of SVG diagrams for a mobile app, a developer can use the custom kernel to slightly blur details, reducing visual noise while preserving overall shape during the SVG‑to‑PNG conversion.
 * 4. When preparing SVG‑based logos for print, a developer might need to apply a subtle sharpening filter defined by the custom kernel to enhance contrast after rasterization, ensuring the PNG output meets print‑ready quality.
 * 5. When building an automated image‑processing pipeline that normalizes SVG assets and applies a consistent smoothing effect across all files, a developer can employ the custom kernel and filter step to guarantee uniform visual appearance in the resulting PNG assets.
 */