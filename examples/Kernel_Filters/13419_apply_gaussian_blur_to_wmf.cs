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
        // Output raster image path (PNG format)
        string outputPath = "output.png";

        // Load the WMF image
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Set up rasterization options for WMF
            WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size,
                BackgroundColor = Color.White
            };

            // Configure PNG options with the vector rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize the WMF image into a memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                wmfImage.Save(ms, pngOptions);
                ms.Position = 0; // Reset stream position for reading

                // Load the rasterized image from the memory stream
                using (Image rasterImg = Image.Load(ms))
                {
                    RasterImage raster = (RasterImage)rasterImg;

                    // Apply Gaussian blur filter (radius: 5, sigma: 4.0) to the entire image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the filtered image as PNG
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}