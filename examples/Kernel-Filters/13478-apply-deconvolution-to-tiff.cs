using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input TIFF file path
        string inputPath = "input.tif";
        // Output image file path (PNG format)
        string outputPath = "output.png";

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access TIFF-specific methods
            TiffImage tiffImage = (TiffImage)image;

            // Apply a motion deconvolution filter to the entire image
            // Parameters: length, smooth value, angle (degrees)
            tiffImage.Filter(tiffImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image as PNG
            tiffImage.Save(outputPath, new PngOptions());
        }
    }
}