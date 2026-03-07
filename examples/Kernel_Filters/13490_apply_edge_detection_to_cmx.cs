using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Paths (adjust as needed)
        string inputCmxPath = "input.cmx";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load CMX image and rasterize to PNG
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputCmxPath))
        {
            cmxImage.Save(tempPngPath, new PngOptions());
        }

        // Load the rasterized PNG, apply edge detection, and save result
        using (Image image = Image.Load(tempPngPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Edge detection kernel (Laplacian)
            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 4, -1 },
                { 0, -1, 0 }
            };

            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
            rasterImage.Filter(rasterImage.Bounds, filterOptions);
            rasterImage.Save(outputPath, new PngOptions());
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}