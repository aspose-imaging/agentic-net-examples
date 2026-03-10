// Path to the folder containing the source CDR file
string dataDir = @"c:\temp\";

// Load the CDR image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.cdr"))
{
    // Cast to RasterImage to access raster operations
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Apply a sharpen filter with kernel size 5 and sigma 4.0 to the whole image
    rasterImage.Filter(
        rasterImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

    // Save the processed image as PNG
    rasterImage.Save(dataDir + "sample.SharpenFilter.png", new Aspose.Imaging.ImageOptions.PngOptions());
}