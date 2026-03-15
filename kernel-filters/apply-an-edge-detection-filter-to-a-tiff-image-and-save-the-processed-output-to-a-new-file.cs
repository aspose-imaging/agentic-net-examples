using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

string dataDir = @"c:\temp\";

// Load the source TIFF image
using (Image image = Image.Load(dataDir + "source.tif"))
{
    // Cast to TiffImage to access TIFF‑specific functionality
    TiffImage tiffImage = (TiffImage)image;

    // Apply an edge detection filter to the whole image
    tiffImage.Filter(tiffImage.Bounds, new EdgeDetectionFilterOptions());

    // Save the processed image as PNG (or any desired format)
    tiffImage.Save(dataDir + "edge_detected.png", new PngOptions());
}