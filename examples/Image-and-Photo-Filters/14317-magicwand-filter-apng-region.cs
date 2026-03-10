using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the APNG image and apply a Gaussian blur filter to a specific region
        using (Image image = Image.Load(inputPath))
        {
            ApngImage apng = (ApngImage)image;
            Rectangle region = new Rectangle(50, 50, 200, 200);
            apng.Filter(region, new GaussianBlurFilterOptions(5, 4.0));
            apng.Save(outputPath, new ApngOptions());
        }

        // Demonstrate MagicWand selection on the same image (as a raster image) and save the result as PNG
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            MagicWandTool
                .Select(raster, new MagicWandSettings(60, 60) { Threshold = 100 })
                .Apply();

            raster.Save("selected.png", new PngOptions());
        }
    }
}