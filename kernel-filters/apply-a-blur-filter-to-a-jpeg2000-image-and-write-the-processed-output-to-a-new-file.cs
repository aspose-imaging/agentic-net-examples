string inputPath = @"C:\Images\sample.jp2";
string outputPath = @"C:\Images\sample_blurred.jp2";

using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
{
    // Cast the loaded image to JPEG2000 specific type
    var jpeg2000Image = (Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image)image;

    // Apply a Gaussian blur filter to the whole image (radius = 5, sigma = 4.0)
    jpeg2000Image.Filter(
        jpeg2000Image.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image as JPEG2000
    jpeg2000Image.Save(outputPath, new Aspose.Imaging.ImageOptions.Jpeg2000Options());
}