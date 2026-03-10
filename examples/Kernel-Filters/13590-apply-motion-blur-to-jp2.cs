// Load a JPEG2000 image, apply a motion blur (motion wiener) filter, and save the result.
string inputPath = @"C:\Images\sample.jp2";
string outputPath = @"C:\Images\sample_motionblur.jp2";

using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
{
    // Cast the generic Image to the specific JPEG2000 image type.
    var jpeg2000Image = (Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image)image;

    // Apply a motion wiener filter (used here as a motion blur) to the whole image.
    // Parameters: length = 10, sigma = 1.0, angle = 0 degrees.
    jpeg2000Image.Filter(
        jpeg2000Image.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 0));

    // Save the processed image back to JPEG2000 format.
    jpeg2000Image.Save(outputPath, new Aspose.Imaging.ImageOptions.Jpeg2000Options());
}