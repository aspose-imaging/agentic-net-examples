using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Directory containing the source PNG image.
        string dir = @"c:\temp\";

        // Load the PNG image from file.
        using (Image image = Image.Load(dir + "sample.png"))
        {
            // Cast to RasterImage to gain access to the Filter method.
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gaussian blur filter.
            // Parameters: radius = 5, sigma = 4.0
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the blurred image as a new PNG file.
            rasterImage.Save(dir + "sample.GaussianBlur.png");
        }
    }
}