using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class SharpenImageExample
{
    static void Main()
    {
        // Path to the source image
        string inputPath = @"C:\Images\source.png";

        // Path where the sharpened image will be saved
        string outputPath = @"C:\Images\source_sharpened.png";

        // Load the image using Aspose.Imaging's Load method (lifecycle rule)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Create SharpenFilterOptions.
            // Size defines the kernel size (must be odd), sigma defines the sharpening intensity.
            // These values can be adjusted as needed.
            SharpenFilterOptions sharpenOptions = new SharpenFilterOptions(5, 4.0);

            // Apply the sharpen filter to the entire image bounds.
            // This preserves the original dimensions and color information.
            rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

            // Save the processed image using the Save method (lifecycle rule)
            // The format is inferred from the file extension (.png).
            rasterImage.Save(outputPath);
        }
    }
}