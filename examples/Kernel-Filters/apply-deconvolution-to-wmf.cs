using System;
using System.Drawing; // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DeconvolutionFilterExample
{
    static void Main()
    {
        // Input WMF file path
        string inputPath = @"C:\Temp\sample.wmf";

        // Output image path (PNG format after applying the filter)
        string outputPath = @"C:\Temp\sample_deconvolved.png";

        // Load the WMF image. Aspose.Imaging loads WMF as a MetafileImage,
        // which can be cast to RasterImage for raster operations like filtering.
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method.
            // If the cast fails, the image format does not support raster filtering.
            RasterImage rasterImage = image as RasterImage;
            if (rasterImage == null)
            {
                throw new InvalidOperationException("The loaded image cannot be processed as a raster image.");
            }

            // Apply a deconvolution filter.
            // Here we use GaussWienerFilterOptions (a concrete DeconvolutionFilterOptions).
            // Parameters: radius = 5, sigma = 4.0 (adjust as needed).
            var deconvolutionOptions = new GaussWienerFilterOptions(5, 4.0);

            // Apply the filter to the whole image bounds.
            rasterImage.Filter(rasterImage.Bounds, deconvolutionOptions);

            // Save the processed image as PNG.
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}