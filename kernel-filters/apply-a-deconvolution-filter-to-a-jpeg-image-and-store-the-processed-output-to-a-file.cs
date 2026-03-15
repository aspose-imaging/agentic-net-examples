using System;
using System.Drawing;                     // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the source JPEG image
        string inputPath = @"C:\Images\source.jpg";

        // Path where the processed image will be saved
        string outputPath = @"C:\Images\deconvolved.png";

        // Load the JPEG image using Aspose.Imaging's lifecycle method
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            var rasterImage = (RasterImage)image;

            // Define a simple deconvolution kernel (e.g., sharpening kernel)
            // The kernel can be any array of doubles; here we use a 3x3 example.
            double[] kernel = new double[]
            {
                0, -1, 0,
               -1, 5, -1,
                0, -1, 0
            };

            // Create Deconvolution filter options with the kernel
            var deconvOptions = new DeconvolutionFilterOptions(kernel)
            {
                // Optional: adjust brightness (default 1.15) and SNR if needed
                Brightness = 1.15,
                Snr = 0.007,
                Grayscale = false   // Process in RGB mode
            };

            // Apply the deconvolution filter to the entire image bounds
            rasterImage.Filter(rasterImage.Bounds, deconvOptions);

            // Save the processed image to the desired output file (PNG format in this case)
            rasterImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
        }
    }
}