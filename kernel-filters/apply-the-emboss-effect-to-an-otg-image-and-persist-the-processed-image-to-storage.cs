using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Paths
        string inputPath = "input.otg";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Step 1: Rasterize OTG to PNG
        using (Image otgImage = Image.Load(inputPath))
        {
            var rasterOptions = new Aspose.Imaging.ImageOptions.OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };
            otgImage.Save(tempPngPath, pngOptions);
        }

        // Step 2: Load raster PNG and apply Emboss filter
        using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
        {
            var embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
            var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
            raster.Filter(raster.Bounds, embossOptions);

            // Step 3: Save the processed image
            var source = new FileCreateSource(outputPath, false);
            var saveOptions = new PngOptions { Source = source };
            raster.Save(outputPath, saveOptions);
        }

        // Cleanup temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}