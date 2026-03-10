using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class ApplyMultipleFiltersToApng
{
    static void Main()
    {
        // Path to the folder containing the source APNG image.
        string dir = @"c:\temp\";

        // Load the existing APNG image.
        using (Image image = Image.Load(dir + "sample.apng"))
        {
            // Cast the generic Image to ApngImage to access APNG‑specific members.
            ApngImage apngImage = (ApngImage)image;

            // Apply a median filter with a rectangle size of 5 to the whole image.
            apngImage.Filter(apngImage.Bounds, new MedianFilterOptions(5));

            // Apply a Gaussian blur filter with radius 5 and sigma 4.0 to the whole image.
            apngImage.Filter(apngImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Apply a sharpen filter with kernel size 5 and sigma 4.0 to the whole image.
            apngImage.Filter(apngImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the filtered APNG image to a new file.
            apngImage.Save(dir + "sample.filtered.apng");
        }
    }
}