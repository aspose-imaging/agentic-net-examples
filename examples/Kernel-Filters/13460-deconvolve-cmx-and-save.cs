using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Paths (adjust as needed)
        string inputCmxPath = "input.cmx";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load CMX vector image and rasterize to PNG
        using (Image cmxImage = Image.Load(inputCmxPath))
        {
            cmxImage.Save(tempPngPath, new PngOptions());
        }

        // Load the rasterized image, apply a deconvolution filter, and save the result
        using (Image rasterImage = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)rasterImage;
            // Apply Gauss-Wiener deconvolution filter with radius 5 and sigma 4.0
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));
            raster.Save(outputPath, new PngOptions());
        }

        // Optionally delete the temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}