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
        // Output PNG file path after applying sharpen filter
        string outputPath = "output.png";

        // Load the EPS image
        using (Image epsImage = Image.Load(epsPath))
        {
            // Rasterize EPS to PNG in memory
            using (MemoryStream rasterStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    // Set rasterization options to match EPS dimensions
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        PageWidth = epsImage.Width,
                        PageHeight = epsImage.Height
                    }
                };

                // Save rasterized image to the memory stream
                epsImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image as a RasterImage
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply sharpen filter to the entire image
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                    // Save the filtered image to the output path
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}