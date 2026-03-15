using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

string inputPath = @"C:\Images\sample.psd";
string outputPath = @"C:\Images\sample_edge.psd";

using (Image image = Image.Load(inputPath))
{
    // Most PSD files are raster based, so cast to RasterImage to access filtering methods
    RasterImage raster = (RasterImage)image;

    // Apply an edge‑detection filter to the entire image area
    raster.Filter(raster.Bounds, new EdgeDetectionFilterOptions());

    // Save the processed image to a new file
    raster.Save(outputPath);
}