using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using System.Drawing;

class GaussWienerFilterExample
{
    static void Main()
    {
        // Path to the folder containing the source image.
        string dataDir = @"c:\temp\";

        // Load the noisy image.
        using (Image image = Image.Load(dataDir + "noisy.png"))
        {
            // Cast to RasterImage to gain access to the Filter method.
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gauss‑Wiener filter.
            // Radius = 5, Sigma (smooth value) = 4.0
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussWienerFilterOptions(5, 4.0));

            // Save the filtered image. The filter reduces noise while preserving edges.
            rasterImage.Save(dataDir + "denoised.png");
        }
    }
}