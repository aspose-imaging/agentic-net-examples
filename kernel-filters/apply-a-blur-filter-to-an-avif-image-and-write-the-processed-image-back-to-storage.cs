using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.AVIF;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class AvifBlurExample
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\Images\sample.avif";
        string outputPath = @"C:\Images\sample_blurred.avif";

        // Load the AVIF image from storage
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to AvifImage to access AVIF‑specific members
            AvifImage avif = (AvifImage)image;

            // Define blur parameters: radius and sigma
            int radius = 5;          // size of the kernel
            double sigma = 4.0;      // standard deviation

            // Apply a Gaussian blur filter to the whole image
            avif.Filter(avif.Bounds, new GaussianBlurFilterOptions(radius, sigma));

            // Save the processed image back to AVIF format
            avif.Save(outputPath, new AvifOptions());
        }
    }
}