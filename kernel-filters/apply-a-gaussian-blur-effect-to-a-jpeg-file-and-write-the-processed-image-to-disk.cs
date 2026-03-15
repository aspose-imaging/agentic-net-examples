// Path to the folder containing the source JPEG image
string dataDir = @"c:\temp\";

// Load the JPEG image using Aspose.Imaging's Image.Load method
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "input.jpg"))
{
    // Cast the loaded image to RasterImage to access raster-specific operations
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Apply a Gaussian blur filter to the entire image.
    // Radius = 5, Sigma = 4.0 (adjust these values as needed)
    rasterImage.Filter(
        rasterImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image back to disk as a JPEG file
    rasterImage.Save(dataDir + "output.jpg");
}