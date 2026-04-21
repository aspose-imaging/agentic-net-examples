using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

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
            RasterImage raster = (RasterImage)image;

            // Define a simple blur kernel (e.g., 3x3 box blur)
            double[,] kernel = new double[,]
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };

            // Compute the sum of all kernel elements
            double sum = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
                for (int j = 0; j < kernel.GetLength(1); j++)
                    sum += kernel[i, j];

            // Normalize the kernel so that its total sum equals one
            for (int i = 0; i < kernel.GetLength(0); i++)
                for (int j = 0; j < kernel.GetLength(1); j++)
                    kernel[i, j] /= sum;

            // Apply the custom convolution filter to the entire image
            var filterOptions = new ConvolutionFilterOptions(kernel);
            raster.Filter(raster.Bounds, filterOptions);

            // Save the processed image as BMP
            BmpOptions bmpOptions = new BmpOptions();
            raster.Save(outputPath, bmpOptions);
        }
    }
}