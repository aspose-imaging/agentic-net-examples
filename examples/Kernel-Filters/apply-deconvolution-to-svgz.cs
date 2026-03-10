using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class DeconvolutionOnSvgz
{
    static void Main()
    {
        // Paths for input SVGZ and output PNG
        string inputSvgzPath = @"D:\Compressed\example.svgz";
        string outputPngPath = @"D:\Compressed\example_deconvolved.png";

        // Step 1: Load the compressed SVGZ image
        using (Image svgzImage = Image.Load(inputSvgzPath))
        {
            // Step 2: Rasterize the SVGZ to a PNG stored in a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Configure rasterization options based on the vector image size
                VectorRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgzImage.Size // preserve original dimensions
                };

                // Save the rasterized image to the memory stream as PNG
                svgzImage.Save(rasterStream, new PngOptions { VectorRasterizationOptions = rasterOptions });
                rasterStream.Position = 0; // reset stream for reading

                // Step 3: Load the rasterized PNG as a RasterImage to apply filters
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    // Cast to RasterImage to access the Filter method
                    var raster = (RasterImage)rasterImage;

                    // Step 4: Apply a deconvolution filter (Gauss-Wiener as an example)
                    var deconvOptions = new GaussWienerFilterOptions
                    {
                        Radius = 5,          // kernel radius
                        Sigma = 4.0,         // Gaussian sigma
                        Snr = 0.007,         // signal-to-noise ratio (default)
                        Brightness = 1.15,   // optional brightness adjustment
                        Grayscale = false    // keep color
                    };

                    // Apply the filter to the entire image bounds
                    raster.Filter(raster.Bounds, deconvOptions);

                    // Step 5: Save the filtered image to the desired output file
                    raster.Save(outputPngPath);
                }
            }
        }
    }
}