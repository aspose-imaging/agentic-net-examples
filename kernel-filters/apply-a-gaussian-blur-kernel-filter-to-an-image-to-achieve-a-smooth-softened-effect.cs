using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Paths for input and output images
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample.GaussianBlur.png";

        // Load the image from disk
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to gain access to the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Define Gaussian blur parameters
            int kernelSize = 5;      // Must be a positive odd integer
            double sigma = 4.0;      // Positive non‑zero sigma value

            // Apply Gaussian blur to the entire image area
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(kernelSize, sigma));

            // Save the blurred image back to disk
            rasterImage.Save(outputPath);
        }
    }
}