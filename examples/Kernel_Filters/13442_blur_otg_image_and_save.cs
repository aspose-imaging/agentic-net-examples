using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = args.Length > 0 ? args[0] : "input.otg";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Temporary rasterized PNG path
        string tempPath = Path.Combine(Path.GetDirectoryName(outputPath) ?? "", "temp.png");

        // Rasterize OTG to PNG
        using (Image otgImage = Image.Load(inputPath))
        {
            PngOptions pngOptions = new PngOptions();
            OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };
            pngOptions.VectorRasterizationOptions = rasterOptions;
            otgImage.Save(tempPath, pngOptions);
        }

        // Load rasterized image, apply Gaussian blur, and save result
        using (Image rasterImageContainer = Image.Load(tempPath))
        {
            RasterImage rasterImage = (RasterImage)rasterImageContainer;
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
            rasterImage.Save(outputPath);
        }

        // Clean up temporary file
        if (File.Exists(tempPath))
        {
            File.Delete(tempPath);
        }
    }
}