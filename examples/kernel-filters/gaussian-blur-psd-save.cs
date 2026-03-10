using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Psd; // PSD format support

class Program
{
    static void Main()
    {
        // Paths to the source PSD file and the destination file
        string inputPath = "input.psd";
        string outputPath = "output.psd";

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage (PsdImage derives from RasterImage) to use the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur to the whole image.
            // Parameters: kernel size = 5, sigma = 4.0
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the blurred image back to PSD format
            rasterImage.Save(outputPath);
        }
    }
}