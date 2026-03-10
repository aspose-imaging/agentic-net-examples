using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output TIFF files
        string inputPath = "input.tif";
        string outputPath = "output_sharpened.tif";

        // Load the existing TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access TIFF-specific methods
            TiffImage tiffImage = (TiffImage)image;

            // Apply a sharpen filter to the whole image
            // Kernel size = 5, sigma = 4.0 (as per example)
            tiffImage.Filter(tiffImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Prepare save options for TIFF format
            TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the filtered image as a new TIFF file
            tiffImage.Save(outputPath, saveOptions);
        }
    }
}