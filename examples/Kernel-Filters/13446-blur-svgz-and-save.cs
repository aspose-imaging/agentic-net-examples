using System;
using System.Drawing;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Path to the input compressed SVG (SVGZ) file
        string inputPath = @"D:\Compressed\example.svgz";

        // Path to the output blurred image (PNG format)
        string outputPath = @"D:\Compressed\example_blurred.png";

        // Load the SVGZ image
        using (Image svgImage = Image.Load(inputPath))
        {
            // Rasterize the vector image to a PNG stored in a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Set up rasterization options for the SVG
                SvgRasterizationOptions vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size // preserve original size
                };

                // PNG save options with the vector rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save the rasterized image to the memory stream
                svgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // reset stream for reading

                // Load the rasterized image from the memory stream
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    // Cast to RasterImage to access the Filter method
                    RasterImage raster = (RasterImage)rasterImage;

                    // Apply a Gaussian blur filter to the whole image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the blurred raster image to the desired output file
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}