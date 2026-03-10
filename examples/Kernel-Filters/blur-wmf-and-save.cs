using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input WMF file path
        string inputPath = "input.wmf";
        // Output blurred image path (PNG format)
        string outputPath = "output_blurred.png";

        // Load the WMF image
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Set up rasterization options to convert WMF to raster format
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size,
                BackgroundColor = Color.White
            };

            // Define PNG options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Render WMF to a memory stream as PNG
            using (MemoryStream ms = new MemoryStream())
            {
                wmfImage.Save(ms, pngOptions);
                ms.Position = 0; // Reset stream position for reading

                // Load the rendered PNG as a RasterImage
                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    // Apply Gaussian blur filter (radius 5, sigma 4.0) to the entire image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the blurred image
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}