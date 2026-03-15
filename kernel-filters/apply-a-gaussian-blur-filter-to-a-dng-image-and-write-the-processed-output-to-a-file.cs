// Path to the folder containing the DNG file
string dir = @"c:\temp\";

// Load the DNG image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dir + "sample.dng"))
{
    // Cast the generic Image to DngImage to access DNG‑specific members
    Aspose.Imaging.FileFormats.Dng.DngImage dngImage = (Aspose.Imaging.FileFormats.Dng.DngImage)image;

    // Apply a Gaussian blur filter to the whole image.
    // Radius = 5, Sigma = 4.0 (adjust as needed)
    dngImage.Filter(
        dngImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image. Here we export to PNG, but any supported format can be used.
    dngImage.Save(dir + "sample.GaussianBlur.png", new Aspose.Imaging.ImageOptions.PngOptions());
}