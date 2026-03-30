using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\sample.png";
        string sobelOutputPath = @"C:\Images\output\sample_sobel.png";
        string embossOutputPath = @"C:\Images\output\sample_emboss.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(sobelOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(embossOutputPath));

        // Apply Sobel-like custom kernel
        using (RasterImage sobelImage = (RasterImage)Image.Load(inputPath))
        {
            double[,] sobelKernel = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };
            sobelImage.Filter(sobelImage.Bounds, new ConvolutionFilterOptions(sobelKernel));
            sobelImage.Save(sobelOutputPath);
        }

        // Apply built-in Emboss3x3 kernel
        using (RasterImage embossImage = (RasterImage)Image.Load(inputPath))
        {
            embossImage.Filter(embossImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
            embossImage.Save(embossOutputPath);
        }
    }
}