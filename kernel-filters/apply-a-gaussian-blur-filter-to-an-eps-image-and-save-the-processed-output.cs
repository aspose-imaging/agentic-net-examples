using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input EPS, temporary raster PNG, and final output
        string epsPath = "input.eps";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load the EPS image and rasterize it to a PNG file using default rasterization options
        using (Image epsImage = Image.Load(epsPath))
        {
            epsImage.Save(tempPngPath, new PngOptions());
        }

        // Load the rasterized PNG as a RasterImage, apply Gaussian blur, and save the result
        using (Image image = Image.Load(tempPngPath))
        {
            RasterImage rasterImage = (RasterImage)image;
            rasterImage.Filter(rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
            rasterImage.Save(outputPath, new PngOptions());
        }

        // Clean up the temporary PNG file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}