// Load a CorelDRAW (CDR) image from file
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(@"C:\Temp\sample.cdr"))
{
    // Cast the generic Image to a CdrImage to access CDR‑specific members
    Aspose.Imaging.FileFormats.Cdr.CdrImage cdrImage = (Aspose.Imaging.FileFormats.Cdr.CdrImage)image;

    // Apply a Gaussian blur filter to the whole image.
    // The filter uses a radius of 5 pixels and a sigma of 4.0.
    cdrImage.Filter(
        cdrImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image back to disk (same format, default options)
    cdrImage.Save(@"C:\Temp\sample_blur.cdr");
}