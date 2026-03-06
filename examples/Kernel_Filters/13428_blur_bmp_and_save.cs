using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Path to the source BMP image
        string inputPath = @"c:\temp\input.bmp";

        // Path where the blurred BMP image will be saved
        string outputPath = @"c:\temp\output.bmp";

        // Load the BMP image using Aspose.Imaging's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to gain access to the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gaussian blur filter to the whole image.
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the resulting image using Aspose.Imaging's save rule
            rasterImage.Save(outputPath);
        }
    }
}