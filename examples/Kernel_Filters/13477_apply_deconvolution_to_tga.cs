using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output TGA images
        string inputPath = "input.tga";
        string outputPath = "output.tga";

        // Load the TGA image as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply a Gauss-Wiener deconvolution filter to the entire image
            // Parameters: radius = 5, sigma = 4.0 (example values)
            raster.Filter(raster.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the processed image as TGA
            raster.Save(outputPath, new TgaOptions());
        }
    }
}