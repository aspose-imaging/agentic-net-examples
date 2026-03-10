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
        string outputPath = "output.tif";

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access TIFF-specific methods
            TiffImage tiffImage = (TiffImage)image;

            // Apply a motion blur (motion Wiener) filter to the entire image
            // Parameters: length, smooth value, angle (degrees)
            tiffImage.Filter(tiffImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image as TIFF
            tiffImage.Save(outputPath);
        }
    }
}