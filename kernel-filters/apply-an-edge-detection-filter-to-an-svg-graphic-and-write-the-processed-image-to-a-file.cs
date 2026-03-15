using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path and output raster image path.
        string inputPath = args.Length > 0 ? args[0] : "input.svg";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the SVG image.
        using (Image svgImage = Image.Load(inputPath))
        {
            // Rasterize SVG to PNG in memory.
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Set up rasterization options for SVG.
                var svgRasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = svgRasterOptions
                };

                // Save rasterized PNG to the memory stream.
                svgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image as a RasterImage.
                using (Image rasterImageContainer = Image.Load(rasterStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageContainer;

                    // Define an edge detection kernel.
                    double[,] edgeKernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    // Create convolution filter options with the kernel.
                    var convolutionOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel);

                    // Apply the edge detection filter to the entire image.
                    rasterImage.Filter(rasterImage.Bounds, convolutionOptions);

                    // Save the processed image to the specified output file.
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}