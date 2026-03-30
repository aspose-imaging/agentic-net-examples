using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define a custom Gaussian kernel (example 3x3)
        double[,] kernel = new double[,]
        {
            { 1, 2, 1 },
            { 2, 4, 2 },
            { 1, 2, 1 }
        };

        // Normalize kernel to preserve brightness (sum should be 1)
        double sum = 0;
        for (int y = 0; y < kernel.GetLength(0); y++)
        {
            for (int x = 0; x < kernel.GetLength(1); x++)
            {
                sum += kernel[y, x];
            }
        }

        if (sum != 0)
        {
            for (int y = 0; y < kernel.GetLength(0); y++)
            {
                for (int x = 0; x < kernel.GetLength(1); x++)
                {
                    kernel[y, x] /= sum;
                }
            }
        }

        // Load image, apply custom convolution filter, and save
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply the normalized kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

            // Save result as PNG
            PngOptions options = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            raster.Save(outputPath, options);
        }
    }
}