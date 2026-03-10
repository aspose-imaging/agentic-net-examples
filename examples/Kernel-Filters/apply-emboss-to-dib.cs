// Load a DIB (bitmap) image, apply an emboss filter, and save the result as PNG.
string dataDir = @"c:\temp\";

// Load the image using Aspose.Imaging's Image.Load method.
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.bmp"))
{
    // Cast to RasterImage to access filtering functionality.
    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

    // Create a convolution filter option using the built‑in 3x3 emboss kernel.
    var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);

    // Apply the emboss filter to the entire image area.
    raster.Filter(raster.Bounds, embossOptions);

    // Save the processed image as PNG.
    raster.Save(dataDir + "sample_Emboss.png", new Aspose.Imaging.ImageOptions.PngOptions());
}