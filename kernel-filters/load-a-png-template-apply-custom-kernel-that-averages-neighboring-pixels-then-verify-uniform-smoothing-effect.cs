using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "template.png";
        string outputPath = "smoothed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG template
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Define a 3x3 averaging kernel (each weight = 1/9)
            double[,] kernel = new double[3, 3]
            {
                { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
            };

            // Apply the custom convolution filter to the entire image
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

            // Save the smoothed image
            raster.Save(outputPath);
        }

        // Simple verification message
        Console.WriteLine("Custom averaging kernel applied and image saved.");
    }
}