using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the folder containing the source image.
        string dataDir = @"c:\temp\";

        // Load a raster image.
        using (Image image = Image.Load(dataDir + "sample.png"))
        {
            // Cast to RasterImage to gain access to the Filter method.
            RasterImage raster = (RasterImage)image;

            // Apply a Gauss‑Wiener deconvolution filter (Gaussian deconvolution).
            // Parameters: radius = 5, sigma = 4.0
            raster.Filter(raster.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the result.
            raster.Save(dataDir + "sample.GaussWienerDeconvolution.png");
        }

        // Load another image (or the same one) to demonstrate a motion deconvolution filter.
        using (Image image = Image.Load(dataDir + "sample.png"))
        {
            RasterImage raster = (RasterImage)image;

            // Apply a Motion‑Wiener deconvolution filter.
            // Parameters: length = 10, sigma = 1.0, angle = 90 degrees
            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the result.
            raster.Save(dataDir + "sample.MotionWienerDeconvolution.png");
        }
    }
}