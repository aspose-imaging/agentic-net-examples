using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.svg";
            string outputPath = "Output\\sample_filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Rasterize SVG to a raster image in memory
                var rasterizationOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                using (var memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image
                    using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                    {
                        // Apply convolution filter: GetBlurMotion size 10 angle 120
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(10, 120.0));
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        // Save the filtered raster image
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
 * 1. When a developer needs to create a motion‑blurred version of a vector logo (SVG) for a website banner, they can rasterize the SVG, apply a 10‑pixel blur at 120° and save it as a PNG.
 * 2. When generating thumbnail previews of SVG diagrams that should convey a sense of movement, the code can be used to apply a directional blur filter before exporting the image.
 * 3. When preparing assets for a mobile app UI where SVG icons must be displayed with a subtle motion effect, this snippet rasterizes the SVG, adds a blur filter, and outputs a PNG optimized for the device.
 * 4. When automating the production of marketing materials that require a dynamic, angled blur on vector illustrations, developers can run this C# routine to process batches of SVG files into blurred PNGs.
 * 5. When converting technical SVG schematics into raster images for inclusion in PDF reports while emphasizing a specific direction of focus, the code applies a 120‑degree motion blur and saves the result as a high‑quality PNG.
 */