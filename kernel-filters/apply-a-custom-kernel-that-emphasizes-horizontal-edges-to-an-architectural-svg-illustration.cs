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

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for PNG output
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a memory stream
                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImageWrapper = Image.Load(ms))
                    {
                        var rasterImage = (RasterImage)rasterImageWrapper;

                        // Custom kernel emphasizing horizontal edges (Sobel operator)
                        double[,] kernel = new double[,]
                        {
                            { -1, -2, -1 },
                            {  0,  0,  0 },
                            {  1,  2,  1 }
                        };

                        var filterOptions = new ConvolutionFilterOptions(kernel);

                        // Apply the convolution filter to the entire image
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        // Save the filtered image as PNG
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
 * 1. When a developer needs to generate a printable blueprint preview that highlights horizontal structural lines in an SVG floor plan by converting it to a PNG with a Sobel edge‑detecting kernel.
 * 2. When an engineering web service must automatically create high‑contrast thumbnails of building elevations, emphasizing horizontal edges to make roof and floor details stand out.
 * 3. When a CAD integration tool requires rasterizing SVG schematics to PNG and applying a custom horizontal‑edge filter to improve visual clarity for non‑technical stakeholders.
 * 4. When a real‑estate portal wants to overlay edge‑enhanced PNG renderings of architectural SVGs on map tiles to help users quickly identify floor levels.
 * 5. When a construction‑management app needs to preprocess SVG site layouts into PNG assets with emphasized horizontal edges for downstream computer‑vision analysis such as line detection.
 */