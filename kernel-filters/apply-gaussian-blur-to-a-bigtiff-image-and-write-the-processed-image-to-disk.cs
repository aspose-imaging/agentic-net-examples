using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source BigTIFF image
        string inputPath = "input.tif";

        // Path where the processed image will be saved
        string outputPath = "output.png";

        // Load the image from disk
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to BigTiffImage (inherits from TiffImage)
            BigTiffImage bigTiff = (BigTiffImage)image;

            // Apply Gaussian blur to the entire image area
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            bigTiff.Filter(bigTiff.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image in PNG format
            bigTiff.Save(outputPath, new PngOptions());
        }
    }
}