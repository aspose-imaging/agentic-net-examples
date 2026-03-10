using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output_deconvolution.png";

        // Load the image and cast to RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gauss‑Wiener deconvolution filter (radius = 5, sigma = 4.0)
            rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the filtered image
            rasterImage.Save(outputPath);
        }
    }
}