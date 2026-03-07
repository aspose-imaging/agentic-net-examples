using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input image path
        string inputPath = @"c:\temp\sample.png";
        // Output image path
        string outputPath = @"c:\temp\sample.GaussianBlur.png";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to use the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Define Gaussian blur parameters
            int kernelSize = 5;      // Positive odd integer
            double sigma = 4.0;      // Positive non‑zero value

            // Apply Gaussian blur filter to the entire image
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussianBlurFilterOptions(kernelSize, sigma));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}