using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPathSobel = "output/output_sobel.png";
            string outputPathEmboss = "output/output_emboss.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPathSobel));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathEmboss));

            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                double[,] sobelKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                var sobelOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(sobelKernel);
                rasterImage.Filter(rasterImage.Bounds, sobelOptions);
                var pngOptions = new PngOptions();
                rasterImage.Save(outputPathSobel, pngOptions);
            }

            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                double[,] embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
                var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
                rasterImage.Filter(rasterImage.Bounds, embossOptions);
                var pngOptions = new PngOptions();
                rasterImage.Save(outputPathEmboss, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}