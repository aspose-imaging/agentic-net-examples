using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Define the folder containing the source PNG image.
        string dir = @"c:\temp\";

        // Load the PNG image from file.
        using (Image image = Image.Load(dir + "sample.png"))
        {
            // Cast the loaded image to RasterImage to access filtering functionality.
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter to the entire image.
            // Kernel size = 5, sigma = 4.0 (as used in the documentation example).
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image to a new file.
            rasterImage.Save(dir + "sample.SharpenFilter.png");
        }
    }
}