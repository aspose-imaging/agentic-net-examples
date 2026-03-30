using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPath = "input.apng";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = "output";

        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            for (int i = 0; i < apng.PageCount; i++)
            {
                string outputPath = Path.Combine(outputDir, $"page_{i}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage frame = (RasterImage)apng.Pages[i])
                {
                    double[,] kernel = ConvolutionFilter.GetBlurMotion(5, 225);
                    var filterOptions = new ConvolutionFilterOptions(kernel);
                    frame.Filter(frame.Bounds, filterOptions);

                    var pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    frame.Save(outputPath, pngOptions);
                }
            }
        }
    }
}