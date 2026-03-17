using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

public class Program
{
    public static void Main(string[] args)
    {
        // Paths for input EPS, temporary raster PNG, and final output
        string epsPath = "input.eps";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load the EPS image and rasterize it to PNG
        using (Image epsImage = Image.Load(epsPath))
        {
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = epsImage.Width,
                PageHeight = epsImage.Height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            epsImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply Gaussian blur, and save the result
        using (Image img = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)img;

            // Apply Gaussian blur with radius 5 and sigma 4.0
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            raster.Save(outputPath, new PngOptions());
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}