// Load the source image
string inputPath = @"C:\Images\input.jpg";
string outputPath = @"C:\Images\output.jpg";

using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
{
    // Cast to RasterImage to gain access to the Filter method
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Create a motion blur kernel (size = 9, angle = 45 degrees)
    double[] motionKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(9, 45);

    // Prepare convolution filter options with the custom kernel
    var convolutionOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(motionKernel);

    // Apply the filter to the whole image
    rasterImage.Filter(rasterImage.Bounds, convolutionOptions);

    // Save the processed image
    rasterImage.Save(outputPath);
}