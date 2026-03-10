string inputPath = @"C:\temp\sample.djvu";
string outputPath = @"C:\temp\sample.EdgeDetected.png";

using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
{
    // Cast the loaded image to DjvuImage to access DJVU‑specific methods
    Aspose.Imaging.FileFormats.Djvu.DjvuImage djvuImage = (Aspose.Imaging.FileFormats.Djvu.DjvuImage)image;

    // Apply a sharpen filter (commonly used for edge detection) to the whole image.
    // SharpenFilterOptions takes a kernel size and a sigma value.
    djvuImage.Filter(djvuImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0f));

    // Save the processed image as PNG.
    djvuImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
}