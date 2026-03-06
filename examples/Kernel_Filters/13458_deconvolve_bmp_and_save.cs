using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats;
using System.Drawing;

string inputPath = "input.bmp";
string outputPath = "output.bmp";

using (Image image = Image.Load(inputPath))
{
    // Cast the loaded image to a raster image to access filtering methods
    RasterImage raster = (RasterImage)image;

    // Create deconvolution filter options (Gauss‑Wiener) with desired radius and sigma
    var deconvOptions = new GaussWienerFilterOptions(5, 4.0);

    // Apply the filter to the whole image area
    raster.Filter(raster.Bounds, deconvOptions);

    // Save the processed image back to BMP format
    raster.Save(outputPath);
}