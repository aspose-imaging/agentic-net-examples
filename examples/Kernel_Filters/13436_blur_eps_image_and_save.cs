using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input EPS file path
        string epsPath = "input.eps";
        // Output PNG file path after applying blur
        string outputPath = "output_blur.png";

        // Load the EPS image
        using (Image epsImage = Image.Load(epsPath))
        {
            // Prepare rasterization options to convert EPS to raster image
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = epsImage.Width,
                PageHeight = epsImage.Height
            };

            // Save the rasterized EPS to a memory stream as PNG
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                epsImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image from the memory stream
                using (Image rasterImage = Image.Load(memoryStream))
                {
                    // Cast to RasterImage to apply filter
                    RasterImage raster = (RasterImage)rasterImage;

                    // Apply Gaussian blur filter (radius 5, sigma 4.0) to the whole image
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Save the blurred image to the desired output path
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}