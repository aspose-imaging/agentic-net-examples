using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\sample.png";
            string outputPath = "output\\filtered.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a 3x3 kernel with edge elements 0.1 and center 0.6
                double[,] kernel = new double[3, 3];
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        kernel[y, x] = (x == 1 && y == 1) ? 0.6 : 0.1;
                    }
                }

                // Normalize the kernel
                double sum = 0;
                foreach (double v in kernel) sum += v;
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        kernel[y, x] /= sum;
                    }
                }

                // Apply the convolution filter to the entire image
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the filtered image as PNG
                PngOptions saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}