using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the folder containing the DNG image
        string dir = @"c:\temp\";

        // Load the DNG image
        using (Image image = Image.Load(dir + "sample.dng"))
        {
            // Cast to DngImage to access format‑specific members
            DngImage dngImage = (DngImage)image;

            // Apply a Gaussian blur filter to the whole image
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            dngImage.Filter(
                dngImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG
            dngImage.Save(dir + "sample.Blur.png", new PngOptions());
        }
    }
}