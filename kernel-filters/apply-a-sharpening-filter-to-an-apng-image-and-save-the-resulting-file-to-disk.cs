using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Load the existing APNG image from disk
        using (Image image = Image.Load("input.apng"))
        {
            // Cast the generic Image to ApngImage to access APNG‑specific members
            ApngImage apng = (ApngImage)image;

            // Apply a sharpening filter to the whole image.
            // SharpenFilterOptions(int size, double sigma) – size must be odd, sigma > 0.
            apng.Filter(apng.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed APNG image to a new file
            apng.Save("output_sharpened.apng");
        }
    }
}