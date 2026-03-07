using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Path to the folder containing the source image
        string dir = "c:\\temp\\";
        
        // Load the image
        using (Image image = Image.Load(dir + "sample.png"))
        {
            // Cast to RasterImage to access filtering methods
            RasterImage rasterImage = (RasterImage)image;
            
            // Apply a sharpen filter with a kernel size of 5 and sigma of 4.0 to the entire image
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));
            
            // Save the processed image
            rasterImage.Save(dir + "sample.SharpenFilter.png");
        }
    }
}