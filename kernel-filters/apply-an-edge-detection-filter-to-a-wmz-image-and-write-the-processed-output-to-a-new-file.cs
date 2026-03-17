using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input WMZ file path
        string inputPath = "input.wmz";
        // Temporary rasterized PNG path
        string tempPngPath = "temp.png";
        // Output file path (raster image with edge detection)
        string outputPath = "output.png";

        // Load the WMZ image and rasterize it to PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = vectorImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            vectorImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply edge detection, and save the result
        using (Image rasterImageContainer = Image.Load(tempPngPath))
        {
            var rasterImage = (RasterImage)rasterImageContainer;

            // Edge detection kernel (3x3)
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));
            rasterImage.Save(outputPath);
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}