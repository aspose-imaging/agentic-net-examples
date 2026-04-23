using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output/output_blur.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)image)
                {
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    raster.Save(outputPath, tiffOptions);
                }
            }

            using (Image blurredImage = Image.Load(outputPath))
            {
                TiffImage tiffImage = (TiffImage)blurredImage;
                bool hasAlpha = tiffImage.HasAlpha;
                Console.WriteLine($"HasAlpha after Gaussian blur: {hasAlpha}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}