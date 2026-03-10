using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output PSD file paths
        string inputPath = Path.Combine("C:", "Images", "sample.psd");
        string outputPath = Path.Combine("C:", "Images", "sample_blurred.psd");

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back as PSD
            raster.Save(outputPath);
        }
    }
}