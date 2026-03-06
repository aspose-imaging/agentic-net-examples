// Path to the folder containing the source DIB image
string dataDir = @"c:\temp\";

// Load the DIB image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.dib"))
{
    // Cast to RasterImage to access the Filter method
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Apply Gaussian blur with kernel size 5 and sigma 4.0 to the whole image
    rasterImage.Filter(
        rasterImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image (format inferred from the file extension)
    rasterImage.Save(dataDir + "sample.GaussianBlur.dib");
}