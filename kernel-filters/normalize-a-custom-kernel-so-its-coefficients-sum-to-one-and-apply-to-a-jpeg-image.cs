using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

        double[,] kernel = new double[,]
        {
            { 1, 2, 1 },
            { 2, 4, 2 },
            { 1, 2, 1 }
        };

        double sum = 0;
        for (int i = 0; i < kernel.GetLength(0); i++)
        {
            for (int j = 0; j < kernel.GetLength(1); j++)
            {
                sum += kernel[i, j];
            }
        }

        double[,] normalizedKernel = new double[kernel.GetLength(0), kernel.GetLength(1)];
        for (int i = 0; i < kernel.GetLength(0); i++)
        {
            for (int j = 0; j < kernel.GetLength(1); j++)
            {
                normalizedKernel[i, j] = kernel[i, j] / sum;
            }
        }

        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            rasterImage.Filter(rasterImage.Bounds,
                new ConvolutionFilterOptions(normalizedKernel));

            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90
            };

            image.Save(outputPath, jpegOptions);
        }
    }
}