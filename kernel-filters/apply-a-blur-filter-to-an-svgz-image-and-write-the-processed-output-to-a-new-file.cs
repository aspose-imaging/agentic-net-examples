using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVGZ file path
        string inputPath = "input.svgz";
        // Output blurred image path (PNG format)
        string outputPath = "output.png";

        // Load the compressed SVG (SVGZ) image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Set up rasterization options for SVG
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            // Rasterize SVGZ to a PNG stored in memory
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image from memory
                using (Image rasterImage = Image.Load(memoryStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply Gaussian blur filter to the entire image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the blurred image to the output file
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}