// Path to the folder containing the CMX image
string dataDir = @"c:\temp\";

// Load the CMX image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.cmx"))
{
    // Cast the loaded image to RasterImage to access filtering functionality
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Apply Gaussian blur with a kernel size of 5 and sigma of 4.0 to the whole image
    rasterImage.Filter(rasterImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image (keeping the same CMX format)
    rasterImage.Save(dataDir + "sample.GaussianBlur.cmx");
}