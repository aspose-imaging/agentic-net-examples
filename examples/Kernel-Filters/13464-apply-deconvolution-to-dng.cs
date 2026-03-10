using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the folder containing the DNG file
        string dir = @"c:\temp\";

        // Load the DNG image
        using (Image image = Image.Load(dir + "sample.dng"))
        {
            // Cast to DngImage to access format‑specific members
            DngImage dngImage = (DngImage)image;

            // Apply a Gauss‑Wiener deconvolution filter to the entire image
            // Parameters: radius = 5, sigma = 4.0 (adjust as needed)
            dngImage.Filter(dngImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the filtered image as PNG
            dngImage.Save(dir + "sample.GaussWienerFilter.png", new PngOptions());
        }
    }
}