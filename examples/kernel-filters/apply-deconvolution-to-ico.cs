using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Ico;
using Aspose.Imaging.ImageFilters.FilterOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the folder containing the ICO image
        string dir = @"c:\temp\";

        // Load the ICO image
        using (Image image = Image.Load(dir + "sample.ico"))
        {
            // Cast to IcoImage to access ICO‑specific methods
            IcoImage ico = (IcoImage)image;

            // Create a deconvolution filter (Gauss‑Wiener is a concrete implementation)
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0)
            {
                // Optional: set to true to process in grayscale mode
                Grayscale = false
            };

            // Apply the filter to the whole image
            ico.Filter(ico.Bounds, deconvOptions);

            // Save the processed ICO image
            ico.Save(dir + "sample_deconvolution.ico");
        }
    }
}