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
        // Input SVGZ file path
        string inputPath = "input.svgz";
        // Output raster image path (PNG)
        string outputPath = "output.png";

        // Load the compressed SVGZ image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options to convert SVGZ to raster format
            var vectorRasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = vectorRasterOptions
            };

            // Rasterize the SVGZ into a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                image.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image as RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                {
                    // Create Emboss filter using predefined kernel
                    var embossKernel = ConvolutionFilter.Emboss3x3;
                    var filterOptions = new ConvolutionFilterOptions(embossKernel);

                    // Apply the filter to the entire image bounds
                    rasterImage.Filter(rasterImage.Bounds, filterOptions);

                    // Save the filtered image
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}