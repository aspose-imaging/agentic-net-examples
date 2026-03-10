// Path to the folder containing the ICO file
string dataDir = @"c:\temp\";

// Load the ICO image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.ico"))
{
    // Cast to RasterImage to access filtering capabilities
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Apply a sharpen filter to the whole image (kernel size 5, sigma 4.0)
    rasterImage.Filter(rasterImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

    // Save the processed image back to ICO format
    rasterImage.Save(dataDir + "sample_sharpened.ico");
}