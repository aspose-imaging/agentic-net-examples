using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using System.Drawing;

// Path to the source BIGTIFF image
string inputPath = "input.tif";

// Path where the sharpened image will be saved
string outputPath = "output.tif";

using (Image image = Image.Load(inputPath))
{
    // Cast the loaded image to BigTiffImage to access TIFF-specific methods
    BigTiffImage bigTiff = (BigTiffImage)image;

    // Apply a sharpen filter to the entire image area
    // Kernel size = 5, sigma = 4.0 (adjust as needed)
    bigTiff.Filter(bigTiff.Bounds, new SharpenFilterOptions(5, 4.0));

    // Save the modified BIGTIFF image to the specified location
    bigTiff.Save(outputPath);
}