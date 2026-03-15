using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Path to the source BIGTIFF image
        string inputPath = @"C:\Images\source_big.tif";

        // Path where the processed image will be saved
        string outputPath = @"C:\Images\processed_big.tif";

        // Load the BIGTIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to a BigTiffImage to access TIFF‑specific functionality
            BigTiffImage bigTiff = (BigTiffImage)image;

            // Apply a motion blur (motion Wiener) filter to the entire image.
            // Parameters: length (kernel size), sigma (smoothness), angle (direction in degrees)
            var motionOptions = new MotionWienerFilterOptions(10, 1.0, 90.0);
            bigTiff.Filter(bigTiff.Bounds, motionOptions);

            // Save the filtered image back to storage
            bigTiff.Save(outputPath);
        }
    }
}