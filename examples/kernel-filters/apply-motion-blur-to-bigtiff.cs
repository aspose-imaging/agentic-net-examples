using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Paths to the source BIGTIFF image and the output file
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Load the BIGTIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to BigTiffImage to access TIFF-specific methods
            BigTiffImage bigTiff = (BigTiffImage)image;

            // Apply a motion blur (motion wiener) filter to the entire image
            // Parameters: length = 10, smooth = 1.0, angle = 0 degrees
            bigTiff.Filter(
                bigTiff.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 0.0));

            // Save the processed image
            bigTiff.Save(outputPath);
        }
    }
}