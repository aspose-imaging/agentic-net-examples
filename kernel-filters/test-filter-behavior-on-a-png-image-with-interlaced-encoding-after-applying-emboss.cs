using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output_emboss_interlaced.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            var embossKernel = ConvolutionFilter.Emboss3x3;
            var embossOptions = new ConvolutionFilterOptions(embossKernel);
            raster.Filter(raster.Bounds, embossOptions);

            var pngOptions = new PngOptions
            {
                Progressive = true
            };

            raster.Save(outputPath, pngOptions);
        }
    }
}