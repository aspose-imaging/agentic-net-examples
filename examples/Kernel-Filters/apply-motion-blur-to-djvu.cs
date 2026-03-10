// Load the DJVU image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(@"C:\Images\sample.djvu"))
{
    // Cast to DjvuImage to access DJVU‑specific functionality
    Aspose.Imaging.FileFormats.Djvu.DjvuImage djvuImage = (Aspose.Imaging.FileFormats.Djvu.DjvuImage)image;

    // Apply a motion‑blur (motion Wiener) filter to the whole image
    // Parameters: length = 10, smooth = 1.0, angle = 90 degrees
    djvuImage.Filter(
        djvuImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

    // Save the processed image as PNG
    djvuImage.Save(@"C:\Images\sample.MotionBlur.png", new Aspose.Imaging.ImageOptions.PngOptions());
}