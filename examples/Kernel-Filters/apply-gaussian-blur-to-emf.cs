// Path to the folder containing the EMF file
string dataDir = @"c:\temp\";

// Load the EMF image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.emf"))
{
    // Cast the loaded image to RasterImage to enable filtering operations
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Apply a Gaussian blur filter to the whole image.
    // Radius = 5, Sigma = 4.0 (adjust as needed)
    rasterImage.Filter(
        rasterImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image. EMF is a vector format, so we save the rasterized result as PNG.
    rasterImage.Save(dataDir + "sample.GaussianBlur.png", new Aspose.Imaging.ImageOptions.PngOptions());
}