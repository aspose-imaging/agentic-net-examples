// Path to the folder containing the source image
string dataDir = @"c:\temp\";

// Load the image using Aspose.Imaging
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.png"))
{
    // Cast to RasterImage to access filtering capabilities
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Apply a sharpen filter with a kernel size of 5 and sigma of 4.0 to the whole image
    rasterImage.Filter(
        rasterImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

    // Save the processed image
    rasterImage.Save(dataDir + "sample.SharpenFilter.png");
}