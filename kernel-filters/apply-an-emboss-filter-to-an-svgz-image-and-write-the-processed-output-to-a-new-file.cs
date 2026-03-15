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
        // Input SVGZ file path and output PNG file path are passed as arguments.
        string inputPath = args.Length > 0 ? args[0] : "input.svgz";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the compressed SVG (SVGZ) image.
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Set up rasterization options to convert the vector image to a raster format.
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            // Configure PNG save options with the rasterization settings.
            var pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize the SVGZ to a PNG stored in memory.
            using (var memoryStream = new MemoryStream())
            {
                vectorImage.Save(memoryStream, pngSaveOptions);
                memoryStream.Position = 0;

                // Load the rasterized image from the memory stream.
                using (Image rasterImage = Image.Load(memoryStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply the emboss filter using a predefined convolution kernel.
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Save the processed image to the specified output file.
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}