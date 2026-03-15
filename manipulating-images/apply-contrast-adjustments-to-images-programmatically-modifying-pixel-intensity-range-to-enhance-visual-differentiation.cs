using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

string dataDir = @"c:\temp\";

// Load an image (any supported format)
using (Image image = Image.Load(dataDir + "sample.png"))
{
    // Cast to the appropriate image type that supports AdjustContrast.
    // RasterImage works for common raster formats (PNG, JPEG, BMP, etc.).
    RasterImage rasterImage = (RasterImage)image;

    // Apply contrast adjustment.
    // Accepted range is [-100f, 100f]; positive values increase contrast.
    rasterImage.AdjustContrast(40f);

    // Save the processed image. Here we keep the PNG format.
    rasterImage.Save(dataDir + "sample.AdjustContrast.png");
}