string inputPath = @"c:\temp\input.djvu";
string outputPath = @"c:\temp\output_blur.png";

using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
{
    // Cast the generic Image to DjvuImage to access DJVU‑specific functionality
    Aspose.Imaging.FileFormats.Djvu.DjvuImage djvuImage = (Aspose.Imaging.FileFormats.Djvu.DjvuImage)image;

    // Apply a Gaussian blur filter to the whole image.
    // Parameters: radius = 5, sigma = 4.0
    djvuImage.Filter(
        djvuImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Persist the processed image as PNG.
    djvuImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
}