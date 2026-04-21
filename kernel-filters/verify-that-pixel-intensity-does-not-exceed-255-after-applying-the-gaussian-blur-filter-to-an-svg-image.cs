using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = image.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                using (var memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Image rasterImg = Image.Load(memoryStream))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImg;
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                        rasterImage.Save(outputPath, pngOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}