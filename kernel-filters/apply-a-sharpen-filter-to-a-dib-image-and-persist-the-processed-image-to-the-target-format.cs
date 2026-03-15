using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class SharpenDibExample
{
    static void Main()
    {
        // Paths for the source DIB image and the target output file
        string inputPath = @"c:\temp\input.dib";
        string outputPath = @"c:\temp\output.png";

        // Load the DIB image using Aspose.Imaging's Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to RasterImage to access raster-specific operations
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter to the entire image.
            // Kernel size = 5, sigma = 4.0 (as demonstrated in the documentation examples)
            rasterImage.Filter(
                rasterImage.Bounds,
                new SharpenFilterOptions(5, 4.0));

            // Save the processed image to the desired format (PNG in this case)
            rasterImage.Save(outputPath);
        }
    }
}