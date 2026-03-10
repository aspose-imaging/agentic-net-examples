using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Jpeg;

// Path to the source JPEG image
string inputPath = @"C:\Images\source.jpg";

// Path where the blurred image will be saved
string outputPath = @"C:\Images\blurred.jpg";

// Load the JPEG image
using (Image image = Image.Load(inputPath))
{
    // Cast to RasterImage to access filtering capabilities
    RasterImage rasterImage = (RasterImage)image;

    // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image as JPEG
    rasterImage.Save(outputPath);
}