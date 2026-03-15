using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

namespace MotionWienerFilterDemo
{
    class Program
    {
        static void Main()
        {
            // Input image path (any supported format, e.g., PNG, JPEG, GIF, TIFF, WebP)
            string inputPath = @"C:\Images\sample.png";

            // Output image path (saved as PNG to preserve quality)
            string outputPath = @"C:\Images\sample.MotionWienerFilter.png";

            // Motion Wiener filter parameters
            int kernelSize = 10;      // Gaussian kernel size (must be positive odd number)
            double sigma = 1.0;       // Gaussian sigma (smoothing factor)
            double angle = 90.0;      // Motion blur angle in degrees

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access the Filter method
                RasterImage rasterImage = (RasterImage)image;

                // Apply the motion Wiener filter to the entire image bounds
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new MotionWienerFilterOptions(kernelSize, sigma, angle));

                // Save the processed image
                rasterImage.Save(outputPath, new PngOptions());
            }
        }
    }
}