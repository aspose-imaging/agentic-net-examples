using System;
using System.Drawing;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class ApplyApngFilter
{
    static void Main()
    {
        // Define input and output paths
        string dir = @"c:\temp\";
        string inputPath = Path.Combine(dir, "sample.apng");
        string outputPath = Path.Combine(dir, "sample.filtered.png");

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access APNG-specific methods
            ApngImage apngImage = (ApngImage)image;

            // Apply a Gaussian blur filter to the entire image area
            // Rectangle covering the whole image is obtained via apngImage.Bounds
            // GaussianBlurFilterOptions(radius, sigma)
            apngImage.Filter(apngImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Prepare PNG save options (optional: set adaptive filter for better compression)
            PngOptions saveOptions = new PngOptions
            {
                FilterType = PngFilterType.Adaptive
            };

            // Save the filtered image as PNG
            apngImage.Save(outputPath, saveOptions);
        }
    }
}