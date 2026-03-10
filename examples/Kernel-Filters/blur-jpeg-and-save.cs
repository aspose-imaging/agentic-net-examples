using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

string dir = @"c:\temp\";

// Load the JPEG image
using (Image image = Image.Load(dir + "sample.jpg"))
{
    // Cast to a raster image (JpegImage derives from RasterImage)
    RasterImage jpegImage = (RasterImage)image;

    // Apply a Gaussian blur filter to the whole image
    // Radius = 5, Sigma = 4.0 (adjust as needed)
    jpegImage.Filter(jpegImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image as JPEG
    jpegImage.Save(dir + "sample.Blurred.jpg", new JpegOptions());
}