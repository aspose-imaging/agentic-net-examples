using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the folder containing the source PNG.
        string dir = @"c:\temp\";

        // Load the PNG image.
        using (Image image = Image.Load(dir + "input.png"))
        {
            // Cast to RasterImage to gain access to the Filter method.
            RasterImage raster = (RasterImage)image;

            // Create a Gauss‑Wiener deconvolution filter (concrete implementation of DeconvolutionFilterOptions).
            // Parameters: radius = 5, sigma = 4.0
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0)
            {
                // Optional: adjust brightness and signal‑to‑noise ratio if desired.
                Brightness = 1.15,
                Snr = 0.007
            };

            // Apply the filter to the entire image area.
            raster.Filter(raster.Bounds, deconvOptions);

            // Save the processed image as a new PNG file.
            raster.Save(dir + "output.deconvolution.png");
        }
    }
}