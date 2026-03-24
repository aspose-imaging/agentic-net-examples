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
        string inputPath = "input.tga";
        string outputPath = "output.tga";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TGA image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Define a simple edge detection kernel
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Apply convolution filter with the edge detection kernel
            var filterOptions = new ConvolutionFilterOptions(kernel);
            image.Filter(image.Bounds, filterOptions);

            // Save the processed image as TGA
            image.Save(outputPath, new TgaOptions());
        }
    }
}