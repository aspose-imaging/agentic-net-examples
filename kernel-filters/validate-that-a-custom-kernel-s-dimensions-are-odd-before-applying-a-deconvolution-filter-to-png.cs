using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            int kernelSize = 5;
            if (kernelSize % 2 == 0)
            {
                Console.Error.WriteLine("Kernel size must be an odd number.");
                return;
            }

            double[,] kernel = new double[kernelSize, kernelSize];
            double value = 1.0 / (kernelSize * kernelSize);
            for (int y = 0; y < kernelSize; y++)
            {
                for (int x = 0; x < kernelSize; x++)
                {
                    kernel[y, x] = value;
                }
            }

            var deconvOptions = new DeconvolutionFilterOptions(kernel);
            raster.Filter(raster.Bounds, deconvOptions);

            var saveOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            raster.Save(outputPath, saveOptions);
        }
    }
}