using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Create a blur kernel (box blur) of size 5
            double[,] kernel = ConvolutionFilter.GetBlurBox(5);

            // Normalize the kernel so that its sum equals 1
            double sum = 0;
            foreach (double value in kernel)
                sum += value;

            if (sum != 0)
            {
                int rows = kernel.GetLength(0);
                int cols = kernel.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        kernel[i, j] /= sum;
                    }
                }
            }

            // Apply the normalized convolution filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

            // Save the processed image as BMP
            rasterImage.Save(outputPath);
        }
    }
}