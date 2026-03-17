using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Path to the source TIFF image
        string sourcePath = "input.tif";

        // Path where the resulting BIGTIFF will be saved
        string outputPath = "output.tif";

        // Load the source image
        using (Image image = Image.Load(sourcePath))
        {
            // Cast to TiffImage to access TIFF-specific functionality
            TiffImage tiffImage = (TiffImage)image;

            // Apply a Gaussian blur filter to the entire image
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Create a BigTiffImage from the filtered TIFF frames
            BigTiffImage bigTiff = new BigTiffImage(tiffImage.Frames);

            // Save the result as a BIGTIFF file
            bigTiff.Save(outputPath);

            // Dispose the BigTiffImage explicitly
            bigTiff.Dispose();
        }
    }
}