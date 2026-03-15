using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output_deconvolution.jpg";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply a Gauss‑Wiener deconvolution filter (radius 5, sigma 4.0)
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}