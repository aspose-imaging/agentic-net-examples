using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Path to the folder containing the source APNG file
        string dataDir = @"c:\temp\";

        // Load the APNG image
        using (Image image = Image.Load(dataDir + "sample.apng"))
        {
            // Cast the generic Image to ApngImage to access APNG‑specific members
            ApngImage apngImage = (ApngImage)image;

            // Apply a Gaussian blur filter to the entire image.
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            apngImage.Filter(
                apngImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image (keeps APNG format)
            apngImage.Save(dataDir + "sample.GaussianBlur.apng");
        }
    }
}