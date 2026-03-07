using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Paths (adjust as needed)
        string epsPath = "input.eps";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Rasterize EPS to a temporary PNG
        using (EpsImage epsImage = (EpsImage)Image.Load(epsPath))
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

        // Load the rasterized image, apply edge detection, and save the result
        using (Image img = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)img;

            // Simple Laplacian kernel for edge detection
            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 4, -1 },
                { 0, -1, 0 }
            };

            var filterOptions = new ConvolutionFilterOptions(kernel);
            raster.Filter(raster.Bounds, filterOptions);
            raster.Save(outputPath, new PngOptions());
        }
    }
}