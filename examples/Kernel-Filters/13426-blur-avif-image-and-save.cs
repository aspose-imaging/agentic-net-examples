using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input AVIF image path
        string inputPath = "input.avif";
        // Output JPEG image path
        string outputPath = "output.jpg";

        // Load the AVIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur filter with radius 5 and sigma 4.0
            rasterImage.Filter(
                rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the result as JPEG
            rasterImage.Save(outputPath, new JpegOptions());
        }
    }
}