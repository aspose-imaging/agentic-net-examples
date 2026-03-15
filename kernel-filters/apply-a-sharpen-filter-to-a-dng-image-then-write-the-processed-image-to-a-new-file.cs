string dataDir = @"C:\Images\";

// Load the DNG image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.dng"))
{
    // Cast to DngImage to access format‑specific methods
    Aspose.Imaging.FileFormats.Dng.DngImage dngImage = (Aspose.Imaging.FileFormats.Dng.DngImage)image;

    // Apply a sharpen filter to the whole image (kernel size 5, sigma 4.0)
    dngImage.Filter(dngImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

    // Save the processed image as PNG
    dngImage.Save(dataDir + "sample_sharpened.png",
        new Aspose.Imaging.ImageOptions.PngOptions());
}