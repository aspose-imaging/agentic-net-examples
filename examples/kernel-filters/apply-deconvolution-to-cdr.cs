using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;   // Namespace for CDR support (if needed)

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the source CDR file
        string inputPath = @"C:\Temp\sample.cdr";

        // Path for the processed output image (PNG format)
        string outputPath = @"C:\Temp\sample_deconvolved.png";

        // Load the CDR image
        using (Image image = Image.Load(inputPath))
        {
            // CDR files are loaded as RasterImage for pixel‑level operations
            RasterImage raster = (RasterImage)image;

            // Create deconvolution filter options (Gauss‑Wiener is a concrete implementation)
            // Radius = 5, Sigma = 4.0 are typical values; adjust as needed.
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0)
            {
                // Optional: set to true to work in grayscale mode
                Grayscale = false,

                // Optional: tweak brightness and SNR if required
                Brightness = 1.15,
                Snr = 0.007
            };

            // Apply the filter to the entire image bounds
            raster.Filter(raster.Bounds, deconvOptions);

            // Save the result as PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}