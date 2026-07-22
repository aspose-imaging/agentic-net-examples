using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output\\output.png";

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
                // Rasterize SVG to PNG in memory
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    var vectorOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };
                    pngOptions.VectorRasterizationOptions = vectorOptions;

                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load rasterized image
                    using (Image rasterImageContainer = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        // Define custom diagonal edge‑detection kernel (3x3)
                        double[,] kernel = new double[,]
                        {
                            { -1, 0, 1 },
                            {  0, 0, 0 },
                            {  1, 0,-1 }
                        };

                        // Apply convolution filter with the custom kernel
                        var convOptions = new ConvolutionFilterOptions(kernel);
                        rasterImage.Filter(rasterImage.Bounds, convOptions);

                        // Save the filtered image
                        var outPngOptions = new PngOptions();
                        rasterImage.Save(outputPath, outPngOptions);
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
 * 1. When a developer needs to highlight diagonal edges in vector logos by converting SVG files to PNG and applying a custom convolution kernel for sharper visual inspection.
 * 2. When an automated build pipeline must generate edge‑enhanced thumbnails of SVG diagrams for quick preview in web galleries using C# and Aspose.Imaging.
 * 3. When a quality‑control tool scans technical drawings stored as SVG and detects misaligned lines by applying a diagonal edge‑detection filter before saving the result as PNG.
 * 4. When a mobile app backend prepares SVG icons for low‑bandwidth devices by rasterizing them and emphasizing diagonal contours through a custom 3×3 kernel.
 * 5. When a data‑visualization service needs to extract feature outlines from SVG charts by applying a convolution filter that emphasizes diagonal edges and outputs the processed image as PNG.
 */