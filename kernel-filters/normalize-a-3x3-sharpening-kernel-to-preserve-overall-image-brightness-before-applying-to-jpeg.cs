using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            double[,] kernel = ConvolutionFilter.Sharpen3x3;
            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            double sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sum += kernel[i, j];
                }
            }

            double[,] normalizedKernel = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    normalizedKernel[i, j] = kernel[i, j] / sum;
                }
            }

            var convOptions = new ConvolutionFilterOptions(normalizedKernel);
            raster.Filter(raster.Bounds, convOptions);

            var jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            raster.Save(outputPath, jpegOptions);
        }
    }
}