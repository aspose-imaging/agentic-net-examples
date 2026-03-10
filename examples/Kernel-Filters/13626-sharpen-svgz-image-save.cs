using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class SharpenSvgzExample
{
    static void Main()
    {
        // Path to the compressed SVG (SVGZ) file
        string inputFile = @"D:\Compressed\example.svgz";

        // Path for the output raster image (PNG) after sharpening
        string outputFile = @"D:\Compressed\example_sharpened.png";

        // Load the SVGZ image using the standard Image.Load method (lifecycle rule)
        using (Image vectorImage = Image.Load(inputFile))
        {
            // Rasterize the vector image to a raster format (PNG) in memory.
            // This step is required because SharpenFilter works on RasterImage objects.
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Configure rasterization options for SVG
                var svgRasterOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size // preserve original size
                };

                // Set up PNG save options with the rasterization settings
                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = svgRasterOptions
                };

                // Save the rasterized image to the memory stream (lifecycle rule)
                vectorImage.Save(rasterStream, pngSaveOptions);
                rasterStream.Position = 0; // reset stream for reading

                // Load the rasterized image back as a RasterImage
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    // Cast to RasterImage to access the Filter method
                    var raster = (RasterImage)rasterImage;

                    // Apply Sharpen filter to the entire image bounds
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the sharpened raster image to the desired output file (lifecycle rule)
                    raster.Save(outputFile, new PngOptions());
                }
            }
        }
    }
}