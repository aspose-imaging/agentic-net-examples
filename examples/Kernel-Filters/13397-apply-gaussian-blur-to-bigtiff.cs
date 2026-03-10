using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Paths to the source BigTIFF image and the destination file
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.tif";

        // Load the BigTIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to BigTiffImage to access TIFF‑specific methods
            BigTiffImage bigTiff = (BigTiffImage)image;

            // Apply a Gaussian blur filter to the entire image.
            // Parameters: kernel size (radius) = 5, sigma = 4.0
            bigTiff.Filter(bigTiff.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the filtered image back to disk
            bigTiff.Save(outputPath);
        }
    }
}