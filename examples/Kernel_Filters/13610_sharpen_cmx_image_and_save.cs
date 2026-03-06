// Path to the folder containing the CMX file
string dataDir = @"C:\Images\";

// Load the CMX image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.cmx"))
{
    // Attempt to treat the loaded image as a raster image.
    // Some vector formats can be rasterized internally and expose RasterImage functionality.
    Aspose.Imaging.RasterImage rasterImage = image as Aspose.Imaging.RasterImage;

    if (rasterImage != null)
    {
        // Apply a sharpen filter with a kernel size of 5 and a sigma value of 4.0 to the whole image.
        rasterImage.Filter(
            rasterImage.Bounds,
            new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

        // Save the processed image in PNG format.
        rasterImage.Save(dataDir + "sample_sharpened.png");
    }
    else
    {
        // If the image cannot be treated as a raster image, you may need to convert it to a raster format first.
        // This fallback simply saves the original CMX without modification.
        image.Save(dataDir + "sample_original.cmx");
    }
}