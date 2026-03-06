using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            TiffImage tiffImage = (TiffImage)image;

            // Apply Gaussian blur filter (radius: 5, sigma: 4.0) to the entire image
            tiffImage.Filter(
                tiffImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as TIFF
            TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffImage.Save(outputPath, saveOptions);
        }
    }
}