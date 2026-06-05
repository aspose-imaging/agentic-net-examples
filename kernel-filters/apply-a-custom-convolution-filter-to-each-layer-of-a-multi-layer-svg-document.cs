using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var svgOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = svgOptions
                };

                using (var rasterStream = new MemoryStream())
                {
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    using (Image rasterImageContainer = Image.Load(rasterStream))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageContainer;

                        double[,] kernel = new double[,]
                        {
                            { -1, -1, -1 },
                            { -1, 8, -1 },
                            { -1, -1, -1 }
                        };

                        rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel, 1.0, 0));

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
 * 1. When a developer needs to automatically sharpen or highlight edges of vector‑based logos stored in multi‑layer SVG files before exporting them as high‑resolution PNG thumbnails for a web catalog, they can use this code to rasterize each layer and apply a custom convolution filter.
 * 2. When an e‑commerce platform wants to generate stylized product icons by applying an emboss or edge‑detect kernel to every layer of a complex SVG illustration and save the result as a PNG for fast client‑side rendering, this snippet provides the C# workflow.
 * 3. When a publishing system must preprocess multi‑layer SVG artwork with a custom contrast‑enhancing convolution matrix before converting it to PNG for print‑ready PDFs, the code demonstrates how to rasterize, filter, and save the image using Aspose.Imaging.
 * 4. When a mobile app needs to create visually consistent badge images by applying a uniform blur or sharpen filter to each SVG layer and then delivering the final PNG assets to the device, the example shows the required steps in C#.
 * 5. When a data‑visualization tool requires on‑the‑fly edge detection on layered SVG charts to improve readability in exported PNG reports, this code illustrates how to load, rasterize, filter, and store the processed image with Aspose.Imaging.
 */