using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class DenoiseApng
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = @"c:\temp\";
        string inputPath = Path.Combine(dataDir, "input.apng");
        string outputPath = Path.Combine(dataDir, "output_denoised.png");

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access raster operations
            ApngImage apng = (ApngImage)image;

            // Apply a median filter (kernel size = 5) to reduce impulsive noise
            apng.Filter(apng.Bounds, new MedianFilterOptions(5));

            // Apply a Gauss‑Wiener filter (radius = 5, sigma = 4.0) for further denoising
            apng.Filter(apng.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the processed image (PNG format)
            apng.Save(outputPath);
        }
    }
}