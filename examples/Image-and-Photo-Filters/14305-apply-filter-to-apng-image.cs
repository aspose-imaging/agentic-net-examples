using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class ApplyApngFilter
{
    static void Main()
    {
        // Path to the folder containing the APNG file
        string dir = @"c:\temp\";

        // Load the APNG image
        using (Image image = Image.Load(dir + "sample.apng"))
        {
            // Cast the generic Image to ApngImage to access APNG-specific methods
            ApngImage apngImage = (ApngImage)image;

            // Apply a Gaussian blur filter to the entire image
            // Parameters: radius = 5, sigma = 4.0
            apngImage.Filter(
                apngImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the filtered image as a PNG file
            apngImage.Save(dir + "sample.filtered.png", new PngOptions());
        }
    }
}