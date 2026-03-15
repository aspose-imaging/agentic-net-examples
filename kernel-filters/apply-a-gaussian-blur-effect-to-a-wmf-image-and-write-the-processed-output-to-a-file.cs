using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Input WMF file path
        string inputPath = "input.wmf";
        // Output raster image path (PNG with Gaussian blur applied)
        string outputPath = "output.png";

        // Load the WMF image
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Set up rasterization options to convert WMF to a raster image
            var rasterizationOptions = new WmfRasterizationOptions
            {
                // Use the original WMF size for the raster canvas
                PageSize = wmfImage.Size,
                // Optional: set a background color for the rasterized image
                BackgroundColor = Color.White
            };

            // Configure PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize the WMF into a memory stream as a PNG
            using (var rasterStream = new MemoryStream())
            {
                wmfImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image from the memory stream
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    // Cast to RasterImage to access filtering capabilities
                    var raster = (RasterImage)rasterImage;

                    // Apply Gaussian blur filter to the entire image
                    // Radius = 5, Sigma = 4.0 (adjust as needed)
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image to the output file
                    raster.Save(outputPath);
                }
            }
        }
    }
}