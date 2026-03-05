using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Apng;

class ApplyApngFilter
{
    static void Main()
    {
        // Path to the source APNG file
        string sourcePath = @"c:\temp\sample.apng";

        // Path for the filtered output image (saved as PNG)
        string outputPath = @"c:\temp\sample.filtered.png";

        // Load the APNG image
        using (Image image = Image.Load(sourcePath))
        {
            // Cast to ApngImage to access APNG‑specific members
            ApngImage apngImage = (ApngImage)image;

            // Define the filter options (e.g., Gaussian blur with radius 5 and sigma 4.0)
            var filterOptions = new GaussianBlurFilterOptions(5, 4.0);

            // Apply the filter to the whole image rectangle
            apngImage.Filter(apngImage.Bounds, filterOptions);

            // Save the filtered image as PNG
            apngImage.Save(outputPath, new PngOptions());
        }
    }
}