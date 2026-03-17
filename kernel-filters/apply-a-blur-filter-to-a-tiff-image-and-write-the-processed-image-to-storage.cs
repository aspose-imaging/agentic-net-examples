using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output_blur.tif";

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access TIFF-specific methods
            TiffImage tiffImage = (TiffImage)image;

            // Apply Gaussian blur filter to the entire image
            tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Prepare TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the processed image
            tiffImage.Save(outputPath, tiffOptions);
        }
    }
}