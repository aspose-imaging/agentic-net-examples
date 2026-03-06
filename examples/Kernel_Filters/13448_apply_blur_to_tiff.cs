string dir = @"c:\temp\";

// Load the source TIFF image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dir + "source.tif"))
{
    // Cast to TiffImage to access TIFF‑specific functionality
    Aspose.Imaging.FileFormats.Tiff.TiffImage tiffImage = (Aspose.Imaging.FileFormats.Tiff.TiffImage)image;

    // Apply a Gaussian blur filter to the whole image (radius = 5, sigma = 4.0)
    tiffImage.Filter(
        tiffImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image back to TIFF format
    tiffImage.Save(dir + "source.Blurred.tif");
}