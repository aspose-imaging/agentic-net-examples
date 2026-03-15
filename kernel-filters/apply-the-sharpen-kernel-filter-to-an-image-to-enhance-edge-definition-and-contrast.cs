// Define the directory containing the source image and where the result will be saved
string dataDir = @"c:\temp\";

// Load the source image (any supported raster format, e.g., PNG)
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.png"))
{
    // Cast the loaded image to RasterImage to access filtering capabilities
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Apply a sharpen filter with a kernel size of 5 and sigma of 4.0 to the entire image
    rasterImage.Filter(
        rasterImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

    // Save the processed image as PNG
    rasterImage.Save(dataDir + "sample.SharpenFilter.png");
}