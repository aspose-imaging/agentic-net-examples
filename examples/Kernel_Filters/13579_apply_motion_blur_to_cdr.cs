// Load a CorelDRAW (CDR) image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(@"C:\Images\sample.cdr"))
{
    // Cast to RasterImage to access raster-specific operations
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Apply a motion blur (using MotionWienerFilterOptions as the available motion filter)
    // Parameters: length = 10, smooth = 1.0, angle = 45 degrees
    var motionOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 45.0);
    rasterImage.Filter(rasterImage.Bounds, motionOptions);

    // Save the processed image as PNG
    rasterImage.Save(@"C:\Images\sample.MotionBlur.png", new Aspose.Imaging.ImageOptions.PngOptions());
}