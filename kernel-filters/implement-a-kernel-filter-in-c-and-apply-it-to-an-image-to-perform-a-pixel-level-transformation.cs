using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image and apply a custom convolution kernel
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Define a 3x3 sharpening kernel
            double[,] kernel = new double[,]
            {
                { 0, -1,  0 },
                { -1, 5, -1 },
                { 0, -1,  0 }
            };

            // Apply the convolution filter using the custom kernel
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}